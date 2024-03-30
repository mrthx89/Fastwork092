#define MyAppName "E4 Storage"
#define MyAppVersion "1.1"
#define MyAppPublisher "YH Dev"
#define MyAppCopyright "Copyright @ 2023 YH Dev"
#define MyAppURL "https://www.linkedin.com/in/yanto-hariyono-64b3a6a3/"
#define MyAppURLSupport "https://www.linkedin.com/in/yanto-hariyono-64b3a6a3/"
#define MyAppURLProduct "https://www.linkedin.com/in/yanto-hariyono-64b3a6a3/"
#define MyAppExeName "E4Storage.App.exe"
#define MyGroupApp "Inventory System"
#define MyYearApp "2024"
#define MyAppId "{0F97CC0E-54E0-4727-B55F-F04648221405}"

[Setup]
AppId={{#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName=Update Sistem Inventory
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURLSupport}
AppUpdatesURL={#MyAppURLProduct}
AppCopyright={#MyAppCopyright}
VersionInfoVersion=1.0.1.1
DefaultDirName={commonpf}\{#MyGroupApp}\E4Storage
OutputDir=Output
OutputBaseFilename=E4Storage_Update
DisableProgramGroupPage=yes
CreateAppDir=no
Compression = lzma
SolidCompression = yes
LanguageDetectionMethod=none
ShowLanguageDialog=no
PrivilegesRequired = admin
SetupIconFile=inventory.ico
CreateUninstallRegKey=no

[Languages]
Name: "indonesian"; MessagesFile: "compiler:Languages\Indonesian.isl";

[Files]
Source: "..\E4Storage.App\bin\Debug\{#MyAppExeName}"; DestDir: "{code:GetAppPath}"; Flags: ignoreversion
Source: "..\E4Storage.App\bin\Debug\*.dll"; DestDir: "{code:GetAppPath}"; Flags: ignoreversion
Source: "..\E4Storage.App\bin\Debug\*.config"; DestDir: "{code:GetAppPath}"; Flags: ignoreversion
Source: "..\E4Storage.App\bin\Debug\system\layouts\*"; DestDir: "{code:GetAppPath}\System\Layouts"; Flags: ignoreversion

[Code]
var
  installDir : string;

function InitializeSetup: Boolean;
var
  ShouldContinue: Boolean;
begin
  ShouldContinue := True;

  // CEK APLIKASI SEDANG JALAN ATAU TIDAK
  if FindWindowByWindowName('E4 Storage') > 0 then
  begin
      MsgBox('Program EM4 Storage sedang dijalankan.'#10'Silakan tutup aplikasi tersebut terlebih dahulu.', mbInformation, MB_OK);
      ShouldContinue := False;
  end;

  if ShouldContinue then
  begin
    RegQueryStringValue(HKEY_LOCAL_MACHINE, 'Software\E4Storage', 'installDir', installDir);

    if installDir = '' then
    begin
        MsgBox('Lokasi instalasi Program E4 Storage tidak ditemukan.'#10'Proses update batal.', mbInformation, MB_OK);
        ShouldContinue := False;
    end
    else
    begin
        ShouldContinue := True;
    end
  end;

  Result := ShouldContinue;
end;

function GetAppPath(Param: string): string;
begin
  RegQueryStringValue(HKEY_LOCAL_MACHINE, 'Software\E4Storage', 'installDir', installDir);

  Result := installDir;
end;
