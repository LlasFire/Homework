for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "HH=%dt:~8,2%" & set "Min=%dt:~10,2%" & set "Sec=%dt:~12,2%"
set fullstamp=%YYYY%-%MM%-%DD%_%HH%-%Min%-%Sec%

if exist "%CD%\bin\Debug\netcoreapp3.0\Logs\Example.log" xcopy "%CD%\bin\Debug\netcoreapp3.0\Logs\Example.log" "%CD%\Logs" /Y

set "myLogFile=%CD%\Logs\Example.log"
set "outputFileName=log_report.%fullstamp%.txt"

cd ..\LogParser
LogParser "Select Level, Count(*) AS CountMessages From %myLogFile% GROUP BY Level" -i:CSV -o:TSV >> %outputFileName%
LogParser "Select Time, Level, Message, Exception From %myLogFile% WHERE Level = 'ERROR'" -i:CSV -o:TSV >> %outputFileName%

move /y %CD%\%outputFileName% %CD%\..\BrainstormSessions\LogReports