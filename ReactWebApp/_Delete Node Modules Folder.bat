
@Echo Off

:: First make sure rimraf is installed
npm install rimraf -g

:: Then use it do delete the node_modules folder
rimraf node_modules

Echo Finished deleting node_modules fodler

pause