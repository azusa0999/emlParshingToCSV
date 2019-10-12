# emlParshingToCSV
eml 파일을 csv로 정리해주는 프로그램입니다.

config.txt 파일을 편집하여 사용하세요.

- TagetDirectory : eml 파일이 있는 경로를 지정해줍니다.
- ExportFileName : 내보내기할 때 파일 이름을 지정합니다.
- CutLineDelimiters : 각 메일에서 수집이 종료될 구분자를 지정합니다. 문자열과 문자열은 ","(콤마)로 구분합니다.(ex : 보낸사람,Original Message,Forward Message)
- NotWriteStrings : 문자열에서 제거할 문자를 지정합니다. 문자열과 문자열은 ","(콤마)로 구분합니다. (ex : 안녕하십니까.,sign,안녕하십니까?,안녕하세요.)
