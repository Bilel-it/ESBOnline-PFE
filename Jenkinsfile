pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'docker-windows'} 
    
     
    
    
    
    stages {    
    
        stage('BUILD') {
            steps{
                checkout scm                
                

                echo "#################### Build  #################"
               
                 
                  //  bat "powershell 'msbuild "ESBOnline\\ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:\\publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish'"

                    //def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
                    //bat "${msbuild} ESBOnline.sln"   


                    powershell '''
                    msbuild "ESBOnline\ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:\publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish
                
                '''
                       
                
                
            }
        }
        
        

        
        
        
        
    }
        
}