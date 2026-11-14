# OculusColorSpaceSetting


Oculus 向けに固定されていた色空間を、接続している HMD が申告する色空間に合わせる MOD です。

## 機能

- `OVRPlugin.SetClientColorDesc(ColorSpace)` に Prefix パッチを適用する
- ゲームが要求した色空間を、`OVRPlugin.GetHmdColorDesc()` が返す HMD 側の色空間で置き換える
- 置き換え前後の色空間をログに出力する
- 有効化時に Harmony パッチを適用し、無効化時に解除する

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.11.1 |
| 依存 MOD | BSIPA ^4.0.5 |
| 対象 | Oculus ランタイム (`Oculus.VR` の `OVRPlugin`) |

## インストール

1. Beat Saber を 1.11.1 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/OculusColorSpaceSetting/releases) から `OculusColorSpaceSetting-0.0.1-bs1.11.1.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

ゲーム内に UI や設定はありません。インストールするだけで、Oculus ランタイム使用時に HMD の色空間が使われます。

## ビルド

```powershell
git clone https://github.com/denpadokei/OculusColorSpaceSetting.git
cd OculusColorSpaceSetting
dotnet build .\OculusColorSpaceSetting\OculusColorSpaceSetting.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。


> GitHub Actions によるビルドは未設定です。manifest の対象バージョン (1.11.1) の OVRPlugin に SetClientColorDesc が含まれず、CI でコードをコンパイルできないため。

## ライセンス

MIT ライセンスです。詳細は [LICENSE](LICENSE) を参照してください。
