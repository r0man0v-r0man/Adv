docker
docker build -t romanovdocker/halupa:release . --no-cache
docker run --rm -p 80:80/tcp -d romanovdocker/halupa:release
docker run --rm -it --entrypoint=/bin/bash romanovdocker/halupa:release, ls - список файлов, cat "имя файла" - просмотреть содержимое файла

dotnet ef:
dotnet ef database update -p adv.dal -s adv.api