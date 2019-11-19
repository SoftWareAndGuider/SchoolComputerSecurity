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
