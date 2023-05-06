pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'windows'} 
    
     
    
    
    
    stages {    
    
        stage('BUILD') {
            steps{
                checkout scm                
                

                echo "#################### Build  #################"
               
                 
                    powershell 'msbuild "ESBOnline\ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:\publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish'
                       
                
                
            }
        }
        
        

        
        
        
        
    }
        
}