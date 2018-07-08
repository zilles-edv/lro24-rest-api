@echo off

SET workingdir=%~dp0

rem C:\nuget\NuGet.exe
SET NUGET_EXE=nuget.exe

rem %WORKSPACE%
SET WORKSPACE=.

rem 1.2.3.4
SET PROG_VERSION=1.8.4.0

rmdir out /s /q
mkdir out

%NUGET_EXE% pack %WORKSPACE%\LRO24.REST.Contract\LRO24.REST.Contract.nuspec -version %PROG_VERSION% -outputdirectory %WORKSPACE%\out  -properties DependencyVersion=%PROG_VERSION% -Symbols
REM %NUGET_EXE% pack %WORKSPACE%\LRO24.REST.Client\LRO24.REST.Client.nuspec -version %PROG_VERSION% -outputdirectory %WORKSPACE%\out  -properties DependencyVersion=%PROG_VERSION% -Symbols

pause