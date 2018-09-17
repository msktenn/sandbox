git checkout -b elasticMapper
git status
git commit -a -m"Mapping elastic data and testing"
git add -a
git push
git pull
git push --set-upstream origin elasticMapper
git commit -a -m"multithreading test"
git push
git pull origin master
git commit -a -m"Pulled Daily Changes To Master"
git push

