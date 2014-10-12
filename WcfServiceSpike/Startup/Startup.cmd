date /t >> "%TEMP%\StartupLog.txt" 2>&1
time /t >> "%TEMP%\StartupLog.txt" 2>&1

if "%EmulatorRunning%" == "true" (
    echo Running in the emulator >> "%TEMP%\StartupLog.txt" 2>&1
) else (
    echo Running in the cloud >> "%TEMP%\StartupLog.txt" 2>&1    
    powershell -NoProfile -ExecutionPolicy Unrestricted .\Startup\Startup.ps1 >> "%TEMP%\StartupLog.txt" 2>&1
)

if %errorlevel% equ 0 (
    echo No errors found >> "%TEMP%\StartupLog.txt" 2>&1
    exit /b 0
) else (
    echo Error found: %errorlevel% >> "%TEMP%\StartupLog.txt" 2>&1
    exit %errorlevel%
)
