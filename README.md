# VR Escape Game for Open Campus (VRGame-OC)

## 概要

これは、大学のオープンキャンパスでの展示用に Unity で制作された VR 脱出ゲームです。
Meta Quest でのプレイを想定しており、来場者（特にVR未経験者）に VR の基本的な操作と楽しさを体験してもらうことを目的としています。
プレイヤーはコントローラーを使って部屋を探索し、いくつかの謎を解いて脱出を目指します。

## 主な機能

* **VRインタラクション**: Meta Quest と XR Interaction Toolkit を使用した基本的なVR操作（移動、視点変更、オブジェクトへのインタラクション）。
* **謎解き要素**:
    * ボタンへの衝突判定を利用した4桁の数字入力パネル。
    * 特定のキー入力によるライトの色変化ギミック。
    * 謎解きの進行度に応じたオブジェクトの表示/非表示制御。
* **部屋移動**: 特定の壁（トリガー）に触れることによるテレポート移動。
* **ゲーム管理**: シンプルなゲーム進行ステータスと謎解きフラグの管理。

## 技術スタック

* **ゲームエンジン**: Unity
* **言語**: C#
* **VR**: XR Interaction Toolkit (Meta Quest 向け)
* **UI**: TextMesh Pro
* **その他**: Unity標準の物理エンジン (Collision, Trigger, Raycast)、Coroutine など

## ファイル構成の概要

* `Assets/Scenes`: ゲームのメインシーン (`SampleScene.unity`, `NaoScene.unity`) が含まれています。
* `Assets/Scripts`: プレイヤー操作、謎解きロジック、ゲーム管理などのC#スクリプトが格納されています。
* `Assets/Prefabs`: ゲーム内で使用されるオブジェクト（ドア、プレイヤー、テレポートポイントなど）のプレハブが格納されています。
* `Assets/3d models`: ステージや家具などの3Dモデル (.dae) と、それに関連するテクスチャ・マテリアルが含まれています。
* `Assets/Quiz`: 謎解きギミックに関連するスクリプト、プレハブ、マテリアルなどがまとめられています。
* `Assets/XR`, `Assets/XRI`, `Assets/Samples`: XR Interaction Toolkit 関連のアセットや設定ファイル、サンプルが含まれています。
* `Packages/manifest.json`: プロジェクトが依存する Unity パッケージリストです。
* `ProjectSettings`: プロジェクト固有の Unity 設定ファイル群です。

## セットアップと実行

1.  適切なバージョンの Unity Editor (Unity Hub経由推奨) でこのプロジェクトを開きます。
2.  `Assets/Scenes` フォルダ内のシーンファイル (例: `SampleScene.unity`) を開きます。
3.  Unity Editor 上部の再生ボタン ▶️ をクリックすると、シミュレーションモードまたは接続されたデバイスでゲームが実行されます。
    * **注意**: Meta Quest 実機で動作させるには、別途 Android ビルド設定と Oculus 連携設定が必要です。
