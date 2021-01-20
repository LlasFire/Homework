/*

This script parses an Event Trace binary log (.etl file) generated by an IIS tracing session
 (on Windows Server 2003 RTM), groups together all the events associated with the same request, 
 and dumps each single request together with the associated event data.

To start an IIS tracing session, use the 'logman start' shell command, specifying the path to a 
 'provider file' containing the names or GUID's of the desired IIS Tracing Providers.

This script requires the "HTTP Service Trace" provider to be enabled for the input trace.

*/



// Get arguments

var szArgs = WScript.Arguments;
if(szArgs.length!=1)
{
	PrintUsage();
	WScript.Quit(-2);
}

var szTraceFilename=szArgs(0); 



// Execute query

var myLogQuery=new ActiveXObject("MSUtil.LogQuery");
var myETWInput=new ActiveXObject("MSUtil.LogQuery.ETWInputFormat");
myETWInput.fMode="full";

var szQuery="SELECT * FROM " + szTraceFilename + " WHERE RequestId IS NOT NULL ORDER BY RequestId, Timestamp, EventNumber";

var recordSet=myLogQuery.Execute(szQuery, myETWInput);

//Get the index of the 'RequestId' field

for(var nRequestIdIndex=0; nRequestIdIndex<recordSet.getColumnCount(); nRequestIdIndex++)
 if(recordSet.getColumnName(nRequestIdIndex) == "RequestId")
  break;




// Dump requests

var szSepLine="-----------------------------------------------------------------------------";
var cchIndent1=2;
var szIndent1=MakeString(" ", cchIndent1);
var cchIndent2=cchIndent1+2;
var szIndent2=MakeString(" ", cchIndent2);


var nReqs=0;

while(!recordSet.atEnd())
{
	var records=new Array();

	//Get first record
	var record=recordSet.getRecord();
	recordSet.moveNext();

	//Get this RequestId
	var currentRequestId=record.getValue("RequestId");

	//Eventually get this Url
	var currentUrl=null;
	if(!record.isNull("Url"))
	 currentUrl=record.getValue("Url");

	//Store all the records with this same RequestId
	records.push(record);
	for(; !recordSet.atEnd(); recordSet.moveNext() )
	{			
		var record=recordSet.getRecord();	

		//Check if this is a new request
		if(record.getValue("RequestId")!=currentRequestId)
		 break;

		records.push(record);

		if(currentUrl==null && !record.isNull("Url"))
		 currentUrl=record.getValue("Url");
	}


	//Now dump these values

	//Dump header
	WScript.Echo(szSepLine);
	var timeStamp=new Date(records[0].getValue("Timestamp"));
	nReqs++;
	WScript.Echo("Request n." + nReqs + ": " + ((currentUrl==null)?"":currentUrl) + " " + currentRequestId + " " + timeStamp.getYear() + "-" + timeStamp.getMonth() + "-" + timeStamp.getDate() + " " + timeStamp.getHours() + ":" + timeStamp.getMinutes() + ":" + timeStamp.getSeconds() + "\r\n");

	//Dump all the other records
	var lastTimestamp=timeStamp;
	for(var r=0; r<records.length; r++)
	{
		var record=records[r];

		//Dump EventName and EventTypeName
		WScript.Echo( szIndent1 + record.getValue("EventName") + ": " + record.getValue("EventTypeName") + " - " + record.getValue("EventTypeDescription"));

		//Dump individual fields
		for(var i=nRequestIdIndex+1; i<recordSet.getColumnCount(); i++)
		 if(!record.isNull(i))
		 {
			WScript.Echo( szIndent2 + recordSet.getColumnName(i) + ": " + record.getValue(i) );
		 }

		WScript.Echo("");

		lastTimeStamp=new Date(record.getValue("Timestamp"));
	}

	WScript.Echo(" Total time: " + (lastTimeStamp.valueOf()-timeStamp.valueOf()) + " msecs");

	//Prompt the user to press a key
	if(!recordSet.atEnd())
	{
		WScript.Echo(szSepLine);
		WScript.Echo("[Hit ENTER...]");
		WScript.StdIn.ReadLine();
	}

	WScript.Echo("");	
}

recordSet.close();

WScript.Echo(szSepLine);

//END

function MakeString(szString, cLen)
{
	var szRet="";
	for(var i=0; i<cLen; i++)
	 szRet+=szString;

	return szRet;
}

function PrintUsage()
{
	WScript.Echo("Usage: DumpTraceReqs_RTM <trace_filename>");
	WScript.Echo("\r\nExample: DumpTraceReqs_RTM myTrace.etl\r\n\r\n");
}