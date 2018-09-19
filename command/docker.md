docker login -u [username] -p [password]
docker pull elasticsearch
docker run --name elastic -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" -d elasticsearch
docker run --name kibana -e ELASTICSEARCH_URL=http://172.16.130.60:9200 -p 5601:5601 -d kibana
docker run --link http://dceqlatldg02.dce.insightglobal.net:9200:elasticsearch -d kibana -p 5601:5601
docker-compose up
docker run --link http://dceqlatldg02.dce.insightglobal.net:9200:elasticsearch -d kibana -p 5601:5601
docker run --link "http://dceqlatldg02.dce.insightglobal.net:9200":elasticsearch -d kibana -p 5601:5601
docker run --name kibana -e ELASTICSEARCH_URL=http://dceqlatldg02.dce.insightglobal.net:9200 -p 5601:5601 -d kibana...
docker run --name kibana466 -e ELASTICSEARCH_URL=http://dceqlatldg02.dce.insightglobal.net:9200 -p 5601:5601 -d kibana:4.6.6...

docker pull elastichq/elasticsearch-hq
docker run --name elasticsearchhq  -p 5000:5000 -d elastichq/elasticsearch-hq

