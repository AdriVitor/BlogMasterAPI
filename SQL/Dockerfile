FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD="BlogMaster123456@@"

WORKDIR /app
COPY QueryDb.sql /app/QueryDb.sql

# Executa o script QueryDb.sql durante a construção da imagem
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -i /app/QueryDb.sql

# Expor a porta 1433 para acesso externo (opcional)
EXPOSE 1433

# CMD agora é apenas para iniciar o SQL Server
CMD ["/opt/mssql/bin/sqlservr"]