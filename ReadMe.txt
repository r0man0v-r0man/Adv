docker
docker build -t romanovdocker/halupa:release .
docker run --rm -p 80:80/tcp -d romanovdocker/halupa:release
docker run --rm -it --entrypoint=/bin/bash romanovdocker/halupa:release, ls - ������ ������, cat "��� �����" - ����������� ���������� �����

dotnet ef:
dotnet ef database update -p adv.dal -s adv.api