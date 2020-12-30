REM EXIT
REM c:\MAMP\bin\nginx\nginx.exe
ECHO Starting php-cgi
c:\MAMP\bin\php\php5.5.12\php-cgi.exe -b 127.0.0.1:9100 -c C:\MAMP\conf\php5.5.12\php.ini
ping 127.0.0.1 -n 1>NUL
echo Starting nginx
echo .
echo .
echo .
ping 127.0.0.1 >NUL
