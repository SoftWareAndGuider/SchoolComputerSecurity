# School Computer Security

School Computer Security (장곡중학교 학급 내 정보화기기 관리 페이지 및 프로그램 서비스, 이하 "서비스")은 다음의 목적을 가진다

* 학급 내 교육용 정보화기기 및 설비의 유지와 관리의 목적
* 교칙 위반사항의 대한 담당선생님의 통제 권한 부여의 목적
* 메세지 서비스를 사용하여 학급-교무실 간 빠른 의사소통의 목적

## 목차

이 문서는 개발자를 위하여 작성되었습니다

- [School Computer Security](#school-computer-security)
  - [목차](#%eb%aa%a9%ec%b0%a8)
  - [개발전 초기 설치](#%ea%b0%9c%eb%b0%9c%ec%a0%84-%ec%b4%88%ea%b8%b0-%ec%84%a4%ec%b9%98)
  - [개발용 실행](#%ea%b0%9c%eb%b0%9c%ec%9a%a9-%ec%8b%a4%ed%96%89)
  - [디버깅](#%eb%94%94%eb%b2%84%ea%b9%85)
    - [로깅 규칙](#%eb%a1%9c%ea%b9%85-%ea%b7%9c%ec%b9%99)
    - [Rest API](#rest-api)
      - [Sec1: 웹페이지](#sec1-%ec%9b%b9%ed%8e%98%ec%9d%b4%ec%a7%80)
        - [GET /](#get)
        - [GET /view](#get-view)
        - [GET /grade(학년)/room(반)/(UUID)](#get-grade%ed%95%99%eb%85%84room%eb%b0%98uuid)
      - [Sec2: 로그인 및 인증](#sec2-%eb%a1%9c%ea%b7%b8%ec%9d%b8-%eb%b0%8f-%ec%9d%b8%ec%a6%9d)
        - [GET /api/auth/genUUID/(학년)/(반)/(비밀번호)](#get-apiauthgenuuid%ed%95%99%eb%85%84%eb%b0%98%eb%b9%84%eb%b0%80%eb%b2%88%ed%98%b8)
      - [Sec3: 맥주소 저장](#sec3-%eb%a7%a5%ec%a3%bc%ec%86%8c-%ec%a0%80%ec%9e%a5)
        - [GET /api/macJson/(맥주소)](#get-apimacjson%eb%a7%a5%ec%a3%bc%ec%86%8c)
        - [GET /api/macJson/(학년)/(반)/(맥주소)](#get-apimacjson%ed%95%99%eb%85%84%eb%b0%98%eb%a7%a5%ec%a3%bc%ec%86%8c)
      - [Sec4: 화면 켑쳐 데이터](#sec4-%ed%99%94%eb%a9%b4-%ec%bc%91%ec%b3%90-%eb%8d%b0%ec%9d%b4%ed%84%b0)
        - [GET /api/imgJson/(학년)/(반)](#get-apiimgjson%ed%95%99%eb%85%84%eb%b0%98)
        - [PUT /api/imgJson/(학년)/(반)](#put-apiimgjson%ed%95%99%eb%85%84%eb%b0%98)
      - [Sec5: 시스템 관리 데이터](#sec5-%ec%8b%9c%ec%8a%a4%ed%85%9c-%ea%b4%80%eb%a6%ac-%eb%8d%b0%ec%9d%b4%ed%84%b0)
        - [GET /api/mgrJson/(학년)/(반)](#get-apimgrjson%ed%95%99%eb%85%84%eb%b0%98)
        - [PUT /api/mgrJson/(학년)/(반)](#put-apimgrjson%ed%95%99%eb%85%84%eb%b0%98)
        - [GET /api/mgrJson/(학년)/(반)/(명령)](#get-apimgrjson%ed%95%99%eb%85%84%eb%b0%98%eb%aa%85%eb%a0%b9)
      - [Sec6: 메세지 송신](#sec6-%eb%a9%94%ec%84%b8%ec%a7%80-%ec%86%a1%ec%8b%a0)
        - [GET /api/msgJson/(학년)/(반)/(메세지)](#get-apimsgjson%ed%95%99%eb%85%84%eb%b0%98%eb%a9%94%ec%84%b8%ec%a7%80)
      - [Sec7: API 디버깅](#sec7-api-%eb%94%94%eb%b2%84%ea%b9%85)
        - [GET /raw/(데이터이름)](#get-raw%eb%8d%b0%ec%9d%b4%ed%84%b0%ec%9d%b4%eb%a6%84)
  - [기여](#%ea%b8%b0%ec%97%ac)
  - [저작권 및 유의사항](#%ec%a0%80%ec%9e%91%ea%b6%8c-%eb%b0%8f-%ec%9c%a0%ec%9d%98%ec%82%ac%ed%95%ad)

## 개발전 초기 설치

[Node.js](https://nodejs.org) `^12.13.1`을 필요로 합니다

이 레포지트리를 다운받습니다:
```sh
git clone https://github.com/SoftWareAndGuider/SchoolComputerSecurity.git
```

다운받은 레포지트리 경로로 이동후, 필수 모듈을 설치합니다:
```sh
npm i 혹은 yarn
```

HashCrypto.js 파일을 작성하여 암호화 알고리즘을 작성하셔야 합니다

## 개발용 실행

파일을 직접 실행합니다:
```
node index
```

혹은 패키지 메니저를 사용할 수 있습니다:
```
npm start 혹은 yarn start
```

## 디버깅

### 로깅 규칙

디버깅 중 로깅의 규칙은 다음과 같습니다

`[(접두사)(작업)] (상세)`

---------

접두사는 다음의 종류가 있습니다

* web : 웹 페이지 관련
* img : 화면 이미지 관련
* uid : 세션 ID 관련
* mac : MAC 주소 관련
* mgr : 관리도구 관련
* msg : 메세지 서비스 관련
* raw : 디버깅 관련

---------

작업은 다음의 종류가 있습니다

* Get : 데이터 읽기 및 수신(파란색)
* Put : 데이터 쓰기 및 송신(초록색)

다음은 접두사가 uid인 경우만 가능한 작업입니다

* Req : 세션 UUID 발급 요청 (마젠타색)
* Gen : 세션 UUID 생성 (시안색)
* Neg : 세션 UUID 발급 거부 (빨간색)

---------

상세는 다음의 종류가 있습니다

* `by (ip)`
* `by (ip) to (id)`
* `by (ip) from (id)`
* `by (ip) from (id) to (newid)`
* `by (ip) at (data)`
* `(학년-반) by (ip)`
* `(학년-반) by (ip) `

### Rest API

Rest API의 대한 레퍼런스입니다, 다음을 확인해 주십시오
* 모든 통신은 HTTP/1.1를 사용합니다
* GET과 PUT 메소드 만을 사용합니다
* 기타 메소드의 대하여 500을 반환합니다
* 접근 권한이 없는경우 403을 반환합니다
* 접근하고자 하는 API의 경로가 잘못되었거나 없을 경우 404를 반환합니다
* 경로의 따라 Content-Type가 달라지므로 참고하시기 바랍니다

#### Sec1: 웹페이지

##### GET /

[`/view`](#get-view)로 리다이렉트

##### GET /view

웹 페이지를 전송합니다
* Content-Type: `text/html`

##### GET /grade(학년)/room(반)/(UUID)

UUID를 검사한후 학년, 반에 맞는 뷰어를 전송합니다
* Content-Type: `text/html`

#### Sec2: 로그인 및 인증

##### GET /api/auth/genUUID/(학년)/(반)/(비밀번호)

학년, 반에 맞는 비밀번호인지 확인한 후 UUID를 생성한 뒤 JSON Object를 반환합니다
```json
// 비밀번호가 틀렸을 경우
{
  "correct": false
}

// 비밀번호가 맞았을 경우
{
  "correct": true,
  "path": "/grade(학년)/room(반)/(UUID)"
}
```

* Content-Type: `application/json`

#### Sec3: 맥주소 저장

##### GET /api/macJson/(맥주소)

DB에 맥주소가 저장되어 있는지 없는지 확인한 후 다음을 따릅니다
* 맥주소가 DB에 없는경우 `Fail` 문자열을 반환합니다
* 맥주소가 DB에 있는경우 `/api/imgJson/(학년)/(반);/api/mgrJson/(학년)/(반);/api/msgJson/(학년)/(반)` 문자열을 반환합니다

* Content-Type: `text/plain`

##### GET /api/macJson/(학년)/(반)/(맥주소)

DB에 맥주소가 저장되어 있는지 없는지 확인한 후 다음을 따릅니다
* 맥주소가 DB에 없는경우 학년, 반, 맥주소를 DB에 작성하고 200을 반환합니다
* 맥주소가 DB에 있는 경우 아무 작업 없이 200을 반환합니다
  
#### Sec4: 화면 켑쳐 데이터

##### GET /api/imgJson/(학년)/(반)

학년, 반에 맞는 화면 켑쳐 데이터를 다음의 형식으로 전송합니다:
```
(모니터1-base64);(모니터2-base64);(모니터3-base64)...
```

* Content-Type `text/plain`

##### PUT /api/imgJson/(학년)/(반)

body로 `text/plain`을 받습니다, body는 다음의 형식이여야 합니다:
```
(모니터1-base64);(모니터2-base64);(모니터3-base64)...
```
최소 하나 이상의 모니터 켑쳐 정보가 base64로 담겨저있어야 합니다

#### Sec5: 시스템 관리 데이터

##### GET /api/mgrJson/(학년)/(반)

학년, 반에 맞는 관리 데이터를 JSON Array로 전송한 후 초기화 합니다
```json
// 형식
[종료, 재시작, 절전, 메세지 유무, 메세지 내용, 명령프롬포트 허가 유무, 작업관리자 허가 유무]

// 초기값
[false, false, false, false, '', false, false]

// 예시) 종료를 요청했을 경우
[true, false, false, false, '', true||false, true||false]

// 예시) 메세지가 있을경우
[false, false, false true, '메세지 내용', true||false, true||false]
```

* Content-Type: `application/json`

##### PUT /api/mgrJson/(학년)/(반)

학년, 반에 맞는 관리 데이터를 다음의 형식으로 받습니다:
```
(명령프롬포트 허가 유무);(작업관리자 허가 유무)
```

##### GET /api/mgrJson/(학년)/(반)/(명령)

몇 학년 몇 반에 명령을 내린후 200을 반환합니다, 명령은 다음을 사용할 수 있습니다:
* `shutdown` : 종료
* `restart` : 재시작
* `powerSave` : 절전

#### Sec6: 메세지 송신

메세지 수신은 [`/api/mgrJson`](#get-apimgrjson%ed%95%99%eb%85%84%eb%b0%98)을 사용하면됩니다

##### GET /api/msgJson/(학년)/(반)/(메세지)

몇 학년, 몇 반에 메세지를 전송한후 200을 반환합니다

#### Sec7: API 디버깅

##### GET /raw/(데이터이름)

변수들의 값을 변환 과정 없이 전송합니다, 데이터 이름은 다음을 사용할 수 있습니다:
* `auths` : 발급된 UUID가 모이는 배열입니다
* `imgData` : 화면 켑쳐 데이터가 저장된 배열입니다
* `mgrData` : 시스템 관리 데이터가 저장된 배열입니다
* `macData` : 맥주소가 담기는 객체입니다

## 기여

PR의 규칙은 딱히 존제하진 않습니다, 하지만 최소한 다음을 따라주시기 바랍니다:
* eslint를 통하여 Standard.js를 준수해 주십시오 (세미콜론 없음, 작은 따옴표 사용)
* package-lock.json을 생성하지 말아주십시오, 생성되었다면 삭제해 주십시오
* hashCrypto.js파일을 올리지 않도록 해주십시오, 암호화 알고리즘이 들어 있습니다
* 커밋이름은 업데이트 내용과 관련있어야 합니다

## 저작권 및 유의사항
> Copyright  2019~2020. 장곡중학교(칠곡) - Software And Guiders, MIT Licensed.

> 모든 저작권은 (칠곡) 장곡중학교와 Software And Guiders(SWAG, 장곡중 소프트웨어 동아리)에 있으며, 무단 복제 및 2차 배포를 금합니다

이 소프트웨어 및 웹페이지, 서버는 장곡중학교(칠곡) 교사님들의 의견을 반영하여 제작되었습니다
