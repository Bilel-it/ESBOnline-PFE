pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'docker-windows'} 
    
     
    
    
    
    stages {   

        stage('Install Git') {
            steps {
                powershell 'Invoke-WebRequest https://github.com/git-for-windows/git/releases/download/v2.31.1.windows.1/Git-2.31.1.1-64-bit.exe -OutFile git.exe'
                powershell '.\\git.exe /SILENT /NORESTART /NOICONS /COMPONENTS="icons,ext\reg/shellhere,assoc,assoc_sh"'
                powershell '[Environment]::SetEnvironmentVariable("Path", "$env:Path;C:/Program Files\Git\bin", "Machine")'
            }
        } 
    
        stage('BUILD') {
            steps{
                checkout scm                
                

                echo "#################### Build  ###########22222######"
               
                 
                  //  bat "powershell 'msbuild "ESBOnline\\ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:\\publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish'"

                    //def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
                    //bat "${msbuild} ESBOnline.sln"   


                    powershell '''
                    msbuild "ESBOnline/ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:/publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish
                
                '''
                       
                
                
            }
        }
        
        

        
        
        
        
    }
        
}