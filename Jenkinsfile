pipeline {
    agent any
    tools{
        maven 'maven_3_9_1'
    }
    stages{
        stage('Verify Branch'){
            steps{
                echo "$GIT_BRANCH"
            }
        }
        stage('Maven Build'){
            steps{
                sh 'mvn clean install'
            }
        }
    }
}