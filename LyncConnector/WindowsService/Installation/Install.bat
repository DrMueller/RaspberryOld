@ECHO OFF

set DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX4%

echo Installing LyncConnectorService...
echo ---------------------------------------------------
InstallUtil /i ../LyncconnectorService.exe
echo ---------------------------------------------------
echo Done.