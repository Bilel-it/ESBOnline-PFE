pipeline {    
    // options { skipDefaultCheckout() }
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

        allcommitId = bat(returnStdout: true, script: 'git rev-parse HEAD').trim()
        commitId = allcommitId.substring(allcommitId.length() - 6)
       // msbuildHome = tool 'Default MSBuild'
       // scannerHome = tool 'SonarScanner for MSBuild'
        
    }
    
     
    
    

    
    stages {   

       // stage('Install Git') {
        //    steps {
          //      powershell(script: '.\install-git.ps1')
            //}
        //} 


        stage('SCM') {
          steps {
            checkout scm
          }
                 }


        stage('SonarQube Analysis') {
          steps{
    
    //withSonarQubeEnv() {
    //  bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" begin /k:\"esbonline\""
    //  bat "\"${msbuildHome}\\MSBuild.exe\" /t:Rebuild"
    //  bat "\"${scannerHome}\\SonarScanner.MSBuild.exe\" end"
    
bat """ 
env
   
SonarScanner.MSBuild.exe begin /k:"esbonline" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="624f95b62804b5cd3d99b8fcffe1e7c6fa6ba85b"
MsBuild.exe /t:Rebuild "$WORKSPACE/ESBOnline/ESBOnline.csproj"
SonarScanner.MSBuild.exe end /d:sonar.login="624f95b62804b5cd3d99b8fcffe1e7c6fa6ba85b"

""" 

    }
    }
  
        



    
        stage('BUILD') {
            steps{
                 
                


                echo "#################### TAG  ###########22222######"
                echo "AllCommit ID: ${commitId}" 
              
                 
                
                 //echo "Commit ID: ${env.COMMIT_ID}"     
                 echo "#################### TAG  ###########22222######"
                

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
               //bat '''
               //    powershell -Command "Compress-Archive -Path 'C:/jenkins/workspace/esbonline' -DestinationPath 'C:/jenkins/workspace/esbonline/publish-${commitId}.zip' -Force" 
                //'''


           bat """
                powershell -Command \"Compress-Archive -Path 'C:/jenkins/workspace/esbonline' -DestinationPath "C:/jenkins/workspace/esbonline/publish-'${commitId}'.zip -Force\"
            """


              //  bat '''
                //        powershell -Command "Compress-Archive -Path 'C:/jenkins/workspace/esbonline' -DestinationPath "C:/jenkins/workspace/esbonline/publish-${commitId}.zip" -Force"

                        
                         
               //'''

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
                    [artifactId: "esbonline-${commitId}-dev",
                    classifier: '',
                    file: "publish-${commitId}.zip",                    
                    type: 'zip']
                    ]

                        );
                        }
                    }
                
            }



            stage('docker build') {
          
            steps {
                bat """
                    powershell -Command "docker build -t esbonline:${commitId} -f ESBOnline/Dockerfile ." 
                """
            }
         } 

         //stage('TAG Image Backend') {
          //  steps{

            //    echo "#################### Tag Image Backend #################"
             //   bat '''
               //     powershell -Command "docker build -t esbonline:dev -f ESBOnline/Dockerfile ." 

//                    docker tag esbonline:dev imagedockerpaas.azurecr.io/backend:${tag}
  //              '''
    //        }
      //  }



      stage("Push image"){
            steps {
                 script{
                    withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'nexuslogin',
                    usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']]) {
                        env.REG_USERNAME = USERNAME
                        env.REG_PASSWORD = PASSWORD
                    }

               bat """ 

               
               docker login --username=${REG_USERNAME} --password=${REG_PASSWORD} http://192.168.0.128:5567
               docker tag esbonline:01 192.168.0.128:5567/esbonline/esbonline:${commitId}
               docker push 192.168.0.128:5567/esbonline/esbonline:${commitId}

                
                """


//docker tag esbonline:01 192.168.0.128:5567/esbonline/esbonline:01
//docker push 192.168.0.128:5567/esbonline/esbonline:01


            }
            }
        }     


           


         

            




        }
}




    


        
        
        
        
    
        







