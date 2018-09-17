az login
az account set -s Production
az vm show --resource-group ResTrak --name elasticvm -d --query publicIps -o tsv
az vm show --resource-group ResTrak --name elasticvm -d --query publicIps -o tsv
az vm deallocate --resource-group ResTrak --name elasticvm
az vm start --resource-group ResTrak --name elasticvm