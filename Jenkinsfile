pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'docker-windows'} 
    
     
    
    

    
    stages {   

        stage('Install Git') {
            steps {
                powershell(script: './install-git.ps1')
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