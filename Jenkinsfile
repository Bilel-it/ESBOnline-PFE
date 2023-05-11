pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'docker-windows'} 

    environment {
        // This can be nexus3 or nexus2
        NEXUS_VERSION = "nexus3"
        // This can be http or https
        NEXUS_PROTOCOL = "http"
        // Where your Nexus is running. 'nexus-3' is defined in the docker-compose file
        NEXUS_URL = "192.168.0.128:8081"
        // Repository where we will upload the artifacttt
        NEXUS_REPOSITORY = "esbonline"
        // Jenkins credential id to authenticate to Nexus OS test3
        NEXUS_CREDENTIAL_ID = "nexus-password"
       
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
                    nexusVersion: 'nexus3', // Specify Nexus version
                    protocol: 'http', // or 'https' depending on your Nexus configuration
                    
                    nexusUrl: '192.168.0.128:8081', // Nexus server URL
                    
                    repository: 'esbonline', // Repository in Nexus
                    
                    credentialsId: 'nexus-password', // Credentials to authenticate with Nexus
                    
                    //artifacts {
                      //  artifact {
                        //    artifactId: 'esbesbonline' // Unique identifier for your artifact
                            //groupId('your-group-id') // Group or organization ID
                            //version('your-version') // Version of the artifact
                            //classifier('') // Optional classifier
                          //  type('zip') // Type of the artifact
                            //fileLocation('*.zip') // Path to the artifact file(s) to upload
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
        }
    }

    
        
        

        
        
        
        
    
        








