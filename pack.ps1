echo "pack: Packaging started"

$root = (split-path -parent $MyInvocation.MyCommand.Definition)

echo "pack: root sets $root"

$version = [System.Reflection.Assembly]::LoadFile("$root\src\Serilog.Enrichers.EnrichedProperties\bin\Release\netstandard2.0\Serilog.Enrichers.EnrichedProperties.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build) 

$nuspec = "{0}{1}{2}{3}" -f ($root, "\src\Serilog.Enrichers.EnrichedProperties\obj\Release\Serilog.Enrichers.EnrichedProperties.", $versionStr ,".nuspec") 

echo "pack: .nuspec file path sets $nuspec"

echo "pack: Compiling .nuspec file"

$compiledNuget = "{0}{1}{2}{3}" -f ($root, "\nuget\Serilog.Enrichers.EnrichedProperties-", $versionStr ,".nuget") 
& $root\NuGet\NuGet.exe pack $nuspec

echo "pack: Nuget file was compiled into $compiledNuget"
