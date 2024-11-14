.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/candidate-v3 --output=./candidatev3map.json --type=mapping
.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/candidate-v3 --output=./candidatev3data.json --type=data
.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/candidate-v3 --output=./candidatev3map.json --type=mapping
.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/candidate-v3 --output=http://127.0.0.1:9200/candidate-v3 --type=data
.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/restrak-user --output=./restrakusermap.json --type=mapping
.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/restrak-user --output=./restrakuserdata.json --type=data
.\node_modules\.bin\elasticdump.cmd --input=http://dceqlatldg02.dce.insightglobal.net:9200/candidate-v3 --output=./candidatev3data_500.json --type=data --size=1
.\node_modules\.bin\elasticdump.cmd --input=./candidatev3map.json --output=http://127.0.0.1:9200/candidate-v3 --type=mapping
.\node_modules\.bin\elasticdump.cmd --input=./candidatev3data_500.json --output=http://127.0.0.1:9200/candidate-v4 --type=data --limit=20
