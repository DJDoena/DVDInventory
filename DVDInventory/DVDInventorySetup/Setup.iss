[Setup]
AppName=DVD Inventory
AppId=DVDInventory
AppVerName=DVD Inventory 3.0.2
AppCopyright=Copyright © Doena Soft. 2010 - 2025
AppPublisher=Doena Soft.
AppPublisherURL=http://doena-journal.net/en/dvd-profiler-tools/
DefaultDirName={commonpf32}\Doena Soft.\DVD Inventory
DefaultGroupName=DVD Inventory
DirExistsWarning=No
SourceDir=..\DVDInventory\bin\x64\Release\net472
Compression=zip/9
AppMutex=InvelosDVDPro
OutputBaseFilename=DVDInventorySetup
OutputDir=..\..\..\..\..\DVDInventorySetup\Setup\DVDInventory
MinVersion=0,6.1sp1
PrivilegesRequired=admin
WizardStyle=modern
DisableReadyPage=yes
ShowLanguageDialog=no
VersionInfoCompany=Doena Soft.
VersionInfoCopyright=2010 - 2025
VersionInfoDescription=DVD Inventory Setup
VersionInfoVersion=3.0.2
UninstallDisplayIcon={app}\djdsoft.ico

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Messages]
WinVersionTooLowError=This program requires Windows XP or above to be installed.%n%nWindows 9x, NT and 2000 are not supported.

[Types]
Name: "full"; Description: "Full installation"

[Files]
Source: "djdsoft.ico"; DestDir: "{app}"; Flags: ignoreversion

Source: "*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "*.pdb"; DestDir: "{app}"; Flags: ignoreversion

Source: "DVDInventory.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "DVDInventory.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "DVDInventory.pdb"; DestDir: "{app}"; Flags: ignoreversion

Source: "de\*.dll"; DestDir: "{app}\de"; Flags: ignoreversion

Source: "Readme\readme.html"; DestDir: "{app}\Readme"; Flags: ignoreversion

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\DVD Inventory"; Filename: "{app}\DVDInventory.exe"; WorkingDir: "{app}"; IconFilename: "{app}\djdsoft.ico"
Name: "{userdesktop}\DVD Inventory"; Filename: "{app}\DVDInventory.exe"; WorkingDir: "{app}"; IconFilename: "{app}\djdsoft.ico"

[Run]

;[UninstallDelete]

[UninstallRun]

[Registry]

[Code]
function IsDotNET4Detected(): boolean;
// Function to detect dotNet framework version 4
// Returns true if it is available, false it's not.
var
dotNetStatus: boolean;
begin
dotNetStatus := RegKeyExists(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4');
Result := dotNetStatus;
end;

function InitializeSetup(): Boolean;
// Called at the beginning of the setup package.
begin

if not IsDotNET4Detected then
begin
MsgBox( 'The Microsoft .NET Framework version 4 is not installed. Please install it and try again.', mbInformation, MB_OK );
Result := false;
end
else
Result := true;
end;