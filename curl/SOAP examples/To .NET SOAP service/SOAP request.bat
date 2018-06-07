curl -k -i -v ^
    -X POST ^
    -H "Accept-Encoding: gzip,deflate" ^
    -H "Content-Type: application/soap+xml;charset=UTF-8;action=\"http://api.example.com/someservice/ISomeService/CreateUser\"" ^
    -H "Host: localhost:1234" ^
    -H "Connection: Keep-Alive" ^
    -H "User-Agent: Apache-HttpClient/4.1.1 (java 1.5)" ^
    -d @soapreq.xml ^
    http://localhost:1234/SomeService.svc
