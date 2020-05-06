[![License: CC0-1.0](https://img.shields.io/badge/License-CC0%201.0-lightgrey.svg)](http://creativecommons.org/publicdomain/zero/1.0/)
[![Actions Status](https://github.com/camypaper/complib/workflows/verify/badge.svg)](https://github.com/camypaper/complib/actions) 
[![GitHub Pages](https://img.shields.io/static/v1?label=GitHub+Pages&message=+&color=brightgreen&logo=github)](https://camypaper.github.io/complib/) 
-------

### これはなに？
- https://bitbucket.org/camypaper/complib の後継です
- テストとかベンチマークとかしながらライブラリ開発をしていきます

### 構成
```ini
.
|-- Benchmark(ベンチマーク用のやつ)
|-- Library(ライブラリ群)
`-- Tests(CI用のテスト)
```

その他は設定などのあれこれが置いてあるぐらいです

### 使い方
- Library にあるコード断片を貼り付けるだけ

### FAQ
- テストを手元で回したい
  - `dotnet build -o ./bin -c Release` をリポジトリ直下で実行して dll を生成してから、適当な手段でスクリプトを実行
- ベンチマークを動かしたい
  - `./Benchmark` で `dotnet run`

### 依存しているもの
- https://github.com/online-judge-tools/verification-helper
    - ライブラリの CI をするやつ
- https://github.com/dotnet/BenchmarkDotNet
    - ベンチマーク用ライブラリ
