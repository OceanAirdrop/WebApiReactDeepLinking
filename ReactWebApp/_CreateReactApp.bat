@echo off

cd /D "%~dp0"
cd ..
echo %cd%
 
:: step 01: ask the user for an app name
set /p appname=Enter a name for your app[lowercase only, no spaces]:
::please enter a name [lowercase only, no spaces]:
echo %appname%

:: step 02: create the app
echo calling npx create-react-app %appname% --template typescript
call npx create-react-app %appname% --template typescript 

:: step 03: cd into the new directory
cd %appname%
echo %cd%

call npm install --save typescript @types/node @types/react-dom
call npm install --save react react-dom react-scripts
call npm install --save react-router react-router-dom @types/react-router @types/react-router-dom

:: step 04: create some standard folders
cd src
echo %cd%

:: step 06: finished!
echo Finished
set /p done=Press enter to finish
