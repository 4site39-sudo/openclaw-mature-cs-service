@echo off
echo ========================================
echo OPENCLAW MATURE C# SERVICE COMPILATION
echo ========================================
echo.

REM Check if compiler exists
if not exist "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" (
    echo ERROR: C# compiler not found!
    echo Please install .NET Framework 4.8
    pause
    exit /b 1
)

REM Compile
echo Compiling Program.cs...
"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" ^
  /out:OpenClawMatureService.exe ^
  /target:exe ^
  /platform:anycpu ^
  /optimize ^
  Program.cs

REM Check result
if exist OpenClawMatureService.exe (
    echo.
    echo ✅ COMPILATION SUCCESSFUL!
    echo File: OpenClawMatureService.exe
    echo Size: %~z0 bytes
    echo.
    echo To start: OpenClawMatureService.exe
) else (
    echo.
    echo ❌ COMPILATION FAILED!
    echo Please check errors above
)

pause
