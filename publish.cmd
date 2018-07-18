REM Publish feature files to Augurk
SET AUGURK_EXE=%~dp0\src\ATW\packages\Augurk.CommandLine.3.2.1\tools\augurk.exe

%AUGURK_EXE% publish --featureFiles %~dp0\src\ATW\Specifications\Features --productName ATW --groupName ATW --language nl-NL --url %1
%AUGURK_EXE% publish --featureFiles %~dp0\src\Rooster\Specifications\Features --productName Rooster --groupName Rooster --language nl-NL --url %1