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




# Indicates that the windowsservercore image will be used as the base image.
FROM mcr.microsoft.com/windows/servercore:ltsc2019
 
# Uses dism.exe to install the IIS role.
RUN dism.exe /online /enable-feature /all /featurename:iis-webserver /NoRestart
 


# Copy everything from current folder on the host into target folder in container
#COPY . c:\inetpub\wwwroot\
#COPY --from=build /publish/. ./
 
# Sets a command or process that will run each time a container is run from the new image.
#CMD [ "cmd" ]




# Installez le rôle Web-Server (IIS)
RUN powershell.exe -Command Install-WindowsFeature Web-Server

# Exposez le port 80 pour les connexions entrantes
EXPOSE 80




RUN setx /M COMPlus_EnableExperimentalFeatures 1
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# Copiez les fichiers de l'étape build /publish dans le répertoire racine web
COPY --from=build /publish/ /inetpub/wwwroot/





# Définissez le répertoire de travail
#WORKDIR /inetpub/wwwroot

# Définissez la commande par défaut à exécuter lorsque le conteneur démarre
#CMD ["powershell.exe", "-NoLogo", "-ExecutionPolicy", "Bypass"]