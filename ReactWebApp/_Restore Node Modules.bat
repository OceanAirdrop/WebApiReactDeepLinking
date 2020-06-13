
@ECHO OFF

echo Step 01 - Deleteing node_modules

(if exist node_modules rmdir node_modules /q /s)

echo Step 02 - Now re-installing node modules

call npm install

pause
