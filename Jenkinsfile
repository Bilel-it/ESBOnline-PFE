pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'windows'} 

    environment {
        // This can be nexus3 or nexus2
        NEXUS_VERSION = 'nexus3'
        // This can be http or https
        NEXUS_PROTOCOL = 'http'
        // Where your Nexus is running. 'nexus-3' is defined in the docker-compose file
        NEXUS_URL = '192.168.0.128:8081'
        // Repository where we will upload the artifacttt
        NEXUS_REPOSITORY = 'esbonline'
        // Jenkins credential id to authenticate to Nexus OS test3
        NEXUS_CREDENTIAL_ID = 'nexus-password'

        tag = sh(returnStdout: true, script: "git log -n 1 --pretty=format:'%H'").trim()
       
    }
    
     
    
    

    
    stages {   

       // stage('Install Git') {
        //    steps {
          //      powershell(script: '.\install-git.ps1')
            //}
        //} 
    
        stage('BUILD') {
            steps{
                checkout scm   
                
                 echo "#################### TAG  ###########22222######"            
                echo ${tag}

                echo "#################### Build  ###########22222######"
               
                 
                  //  bat "powershell 'msbuild "ESBOnline\\ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:\\publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish'"

                    //def msbuild = tool name: 'MSBuild', type: 'hudson.plugins.msbuild.MsBuildInstallation'
                    //bat "${msbuild} ESBOnline.sln"   


                    powershell '''
                    msbuild "ESBOnline/ESBOnline.csproj" /p:Configuration=Debug /p:DeployOnBuild=true /p:PublishUrl="c:/publish" /p:WebPublishMethod=FileSystem /p:DeployDefaultTarget=WebPublish
                
                '''
                       
                
                
            }
        }

         stage('Compress') {
          steps {
                bat '''
                    powershell -Command "Compress-Archive -Path 'C:/jenkins/workspace/esbonline' -DestinationPath 'C:/jenkins/workspace/esbonline/publish.zip' -Force" 
                '''
            }
         }

         stage('upload publish') {
            steps {

                script {
                                
                // Upload artifact to Nexus 
                nexusArtifactUploader (
                    nexusVersion: NEXUS_VERSION, // Specify Nexus version
                    protocol: NEXUS_PROTOCOL, // or 'https' depending on your Nexus configuration
                    
                    nexusUrl: NEXUS_URL, // Nexus server URL
                    
                    repository: NEXUS_REPOSITORY, // Repository in Nexus
                    
                    credentialsId: NEXUS_CREDENTIAL_ID, // Credentials to authenticate with Nexus
                    
                    
                    artifacts: [
                    [artifactId: 'esbonline',
                    classifier: '',
                    file: 'publish.zip',
                    type: 'zip']
                    ]

                        );
                        }
                    }
                
            }



            stage('docker build') {
          
            steps {
                bat '''
                    powershell -Command "docker build -t esbonline:105 -f ESBOnline/Dockerfile ." 
                '''
            }
         }      


           


         

            




        }
}

    


        
        
        
        
    
        








