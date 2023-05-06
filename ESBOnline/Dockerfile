# start with a base image with all the necessary tooling to compile our app
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

# set the working directory inside compilation container to c:\app
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ESBOnline/*.sln ./ESBOnline/
COPY ESBOnline/ESBOnline.csproj ./ESBOnline/
COPY ESBOnline/*.config ./ESBOnline/
COPY BLL/BLL.csproj ./BLL/
COPY ClassLibrary1/ClassLibrary1.csproj ./ClassLibrary1/
COPY ClassLibrary1/*.config ./ClassLibrary1/
COPY DAL/DAL.csproj ./DAL/
COPY DAL/*.config ./DAL/
COPY Encadrement/Encadrement.csproj ./Encadrement/
COPY PlanEtude/PlanEtude.csproj ./PlanEtude/

# restore nuget packages
RUN nuget restore ./ESBOnline/ESBOnline.sln

# copy everything else and build app
COPY . .

# msbuild to publish project folder to c:\publish, which includes only binaries and content files
RUN msbuild "ESBOnline\ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:\publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish

# start with new base image for running asp.net apps (which contains IIS)
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

# enable IIS-ASPNET45 feature
RUN dism /online /enable-feature /featurename:IIS-ASPNET45

# set the working directory inside compilation container to c:\odac
WORKDIR /odac

# copy odac package
COPY ODAC122010Xcopy_x64.zip .

# unzip odac package
RUN powershell -Command "expand-archive -Path 'c:\odac\ODAC122010Xcopy_x64.zip' -DestinationPath 'c:\install\oracleInstall'"

# set the working directory inside compilation container to c:\install\oracleInstall
WORKDIR /install/oracleInstall

# install odac
RUN ".\install.bat odp.net4 c:\oracle odac true;"

# set the working directory inside compilation container to c:\install\oracleInstall
WORKDIR /Oracle/ODP.NET/bin/4

# install odp for .NET
RUN ./oraprovcfg.exe /action:config /product:odp /frameworkversion:v4.0.30319 /providerpath:C:\Oracle\ODP.NET\bin\4\Oracle.DataAccess.dll

# set environment variable
RUN "[Environment]::SetEnvironmentVariable(\"Path\", $env:Path + \";C:\\oracle\\\", [EnvironmentVariableTarget]::Machine)"

# set default work folder to c:\inetpub\wwwroot (IIS root)
WORKDIR /inetpub/wwwroot

# copy files from bin/publish in our sdk container into c:\inetpub\wwwroot
COPY --from=build /publish/. ./