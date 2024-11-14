docker login -u [username] -p [password]

docker pull docker.elastic.co/elasticsearch/elasticsearch:6.6.0
mkdir ~/docker/elasticdata
docker run --name elastic -e 'ES_JAVA_OPTS=-Xms3g -Xmx3g' -v ~/docker/elasticdata:/usr/share/elasticsearch/data -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" -d docker.elastic.co/elasticsearch/elasticsearch:6.6.0
docker run --name elastic  -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" -d docker.elastic.co/elasticsearch/elasticsearch:6.6.0
--Kibana
docker pull kibana
docker run --name kibana -e ELASTICSEARCH_URL=http://restrak.local:9200 -p 5601:5601 -d kibana


docker run --link http://restrak.local:9200:elasticsearch -d kibana -p 5601:5601
docker-compose up
docker run --link http://dceqlatldg02.dce.insightglobal.net:9200:elasticsearch -d kibana -p 5601:5601
docker run --link "http://dceqlatldg02.dce.insightglobal.net:9200":elasticsearch -d kibana -p 5601:5601
docker run --name kibana -e ELASTICSEARCH_URL=http://dceqlatldg02.dce.insightglobal.net:9200 -p 5601:5601 -d kibana...
docker run --name kibana466 -e ELASTICSEARCH_URL=http://dceqlatldg02.dce.insightglobal.net:9200 -p 5601:5601 -d kibana:4.6.6...

docker pull elastichq/elasticsearch-hq
docker run --name elasticsearchhq  -p 5000:5000 -d elastichq/elasticsearch-hq

sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=letsmakemoney' -p 1433:1433 --name sql -d mcr.microsoft.com/mssql/server:2017-latest

--MONGO
docker pull mongo
mkdir ~/docker/mongodata
sudo docker run --name mongo -d -p 27017:27017 -v ~/docker/mongodata:/data/db mongo


--sql 
mkdir ~/docker/sqldata
sudo docker volume create -o device=/Users/dad/docker/sqldata -o type=bind -o o= --name sqldata
sudo docker volume create --name sqldata
sudo docker volume create -o device=/Users/dad/docker/sqldata -o type=tmpfs  --name sqldata
sudo docker volume create -o device=/Users/dad/docker/sqldata -o type=btrfs  --name sqldata
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Spi!pass007^' -p 1433:1433  -mount type=bind,source=~/docker/sqldata,target-/var/opt/mssql --name sql -d mcr.microsoft.com/mssql/server:2017-latest



sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Spi!pass007^' -p 1433:1433 --mount 'type=volume,source=sqldata,target=/var/opt/mssql' --name sql -d mcr.microsoft.com/mssql/server:2017-latest


--mount source=myvol2,target=/app



docker volume create --opt type=tmpfs  --opt device=/Users/dad/docker/sqldata  --opt o=size=100m,uid=1000 --name sqldata


docker volume create --opt type=nfs --opt o=addr=192.168.1.73,rw  --opt device=:/NetworkShare/sqldata sqldata


docker volume create --driver local --opt type=cifs --opt device='//michaels-mini/NetworkShare/sqldata' --opt o='username=dad,password=Juddkn11' sqldata

--opt o='username=dad,password=Juddkn11'