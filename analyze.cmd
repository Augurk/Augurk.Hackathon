REM Analyze and upload results to Augurk
SET AUGURK_CSHARPANALYZER_EXE=%~dp0\src\ATW\packages\Augurk.CSharpAnalyzer.0.1.0-ci0081\tools\win-x64\Augurk.CSharpAnalyzer.exe

%AUGURK_CSHARPANALYZER_EXE% analyze %~dp0\src\ATW\ATW.sln Specifications
%AUGURK_CSHARPANALYZER_EXE% analyze %~dp0\src\Rooster\Rooster.sln Specifications

%AUGURK_CSHARPANALYZER_EXE% upload %1 ATW 0.0.0 %~dp0\src\ATW\ATW.sln
%AUGURK_CSHARPANALYZER_EXE% upload %1 Rooster 0.0.0 %~dp0\src\Rooster\Rooster.sln