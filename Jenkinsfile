pipeline {
    agent any
    stages{
        stage('Verify Branch'){
            steps{
                echo "$GIT_BRANCH"
            }
        }
        stage('Docker Build'){
            steps{
                powershell 'docker images -a'
                powershell(script: """
                    cd Documents/GetLab/MvcMovie
                    docker images -a
                    docker build -t mvcmovie .
                    docker images -a
                    cd ..
                """)
            }
        }
        stage('Start test app'){
            steps{
                powershell(script: """
                    docker-compose up -d
                """)
            }
            post {
                success {
                    echo "App started successfully"
                }
                failure {
                    echo "App failed to start"
                }
            }
        }
        stage('Run Tests'){
            steps {
                powershell(script: """
                    pytest ./tests/test_sample.py
                """)
            }
        }
        stage('Stop test app') {
            steps {
                powershell(script: """
                    docker-compose down
                """)
            }
        }
    }
}