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
                ps(script: 'docker images -a')
                ps(script: """
                    cd documents
                    docker images -a
                    docker build -t mvcmovie .
                    docker images -a
                    cd ..
                """)
            }
        }
        stage('Start test app'){
            steps{
                ps(script: """
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
                ps(script: """
                    pytest ./tests/test_sample.py
                """)
            }
        }
        stage('Stop test app') {
            steps {
                ps(script: """
                    docker-compose down
                """)
            }
        }
    }
}