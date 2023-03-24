pipeline {
    agent any
    tools{
        maven
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