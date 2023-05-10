pipeline {    
    options { skipDefaultCheckout() }
    agent {label 'docker-windows'} 
    
     
    
    

    
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
                    powershell -Command "Compress-Archive -Path 'C:/jenkins/workspace/esbonline' -DestinationPath 'C:/jenkins/workspace/esbonline/publish.zip'" 
                '''
            }
         }

         stage('upload publish') {
            steps {
                                
                // Upload artifact to Nexus 
                nexusArtifactUploader {
                    nexusVersion: nexus3 // Specify Nexus version
                    protocol: http // or 'https' depending on your Nexus configuration
                    
                    nexusUrl: http://192.168.0.128:8081/ // Nexus server URL
                    
                    repository: esbonline // Repository in Nexus
                    
                    credentialsId: nexus-password // Credentials to authenticate with Nexus
                    
                    artifacts {
                        artifact {
                            artifactId('your-artifact-id') // Unique identifier for your artifact
                            groupId('your-group-id') // Group or organization ID
                            version('your-version') // Version of the artifact
                            classifier('') // Optional classifier
                            type('zip') // Type of the artifact
                            fileLocation('publish/*.zip') // Path to the artifact file(s) to upload
                        }
                    }
                }
            }
        }
    }
        
        

        
        
        
        
    }
        






