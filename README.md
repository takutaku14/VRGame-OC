# VR Escape Game for Open Campus (VRGame-OC)

## 概要

[cite_start]これは、大学のオープンキャンパスでの展示用に Unity で制作された VR 脱出ゲームです [cite: 188, 189]。
Meta Quest でのプレイを想定しており、来場者（特にVR未経験者）に VR の基本的な操作と楽しさを体験してもらうことを目的としています。
プレイヤーはコントローラーを使って部屋を探索し、いくつかの謎を解いて脱出を目指します。

## 主な機能

* [cite_start]**VRインタラクション**: Meta Quest と XR Interaction Toolkit を使用した基本的なVR操作（移動、視点変更、オブジェクトへのインタラクション） [cite: 1, 49, 202-207]。
* **謎解き要素**:
    * [cite_start]ボタンへの衝突判定を利用した4桁の数字入力パネル [cite: 33]。
    * [cite_start]特定のキー入力によるライトの色変化ギミック [cite: 190, 191]。
    * [cite_start]謎解きの進行度に応じたオブジェクトの表示/非表示制御 [cite: 33, 34]。
* [cite_start]**部屋移動**: 特定の壁（トリガー）に触れることによるテレポート移動 [cite: 190, 191]。
* [cite_start]**ゲーム管理**: シンプルなゲーム進行ステータスと謎解きフラグの管理 [cite: 190]。

## 技術スタック

* **ゲームエンジン**: Unity
* **言語**: C#
* [cite_start]**VR**: XR Interaction Toolkit (Meta Quest 向け) [cite: 1, 49, 202-207]
* [cite_start]**UI**: TextMesh Pro [cite: 1, 192-201]
* [cite_start]**その他**: Unity標準の物理エンジン (Collision, Trigger, Raycast) [cite: 190, 191]、Coroutine など

## ファイル構成の概要

* [cite_start]`Assets/Scenes`: ゲームのメインシーン (`SampleScene.unity`, `NaoScene.unity`) が含まれています [cite: 1, 188, 189]。
* [cite_start]`Assets/Scripts`: プレイヤー操作、謎解きロジック、ゲーム管理などのC#スクリプトが格納されています [cite: 1, 189-191]。
* [cite_start]`Assets/Prefabs`: ゲーム内で使用されるオブジェクト（ドア、プレイヤー、テレポートポイントなど）のプレハブが格納されています [cite: 1, 31, 32]。
* [cite_start]`Assets/3d models`: ステージや家具などの3Dモデル (.dae) と、それに関連するテクスチャ・マテリアルが含まれています [cite: 1, 2-31]。
* [cite_start]`Assets/Quiz`: 謎解きギミックに関連するスクリプト、プレハブ、マテリアルなどがまとめられています [cite: 1, 32-38]。
* [cite_start]`Assets/XR`, `Assets/XRI`, `Assets/Samples`: XR Interaction Toolkit 関連のアセットや設定ファイル、サンプルが含まれています [cite: 1, 38-187, 202-207]。
* [cite_start]`Packages/manifest.json`: プロジェクトが依存する Unity パッケージリストです [cite: 207]。
* [cite_start]`ProjectSettings`: プロジェクト固有の Unity 設定ファイル群です [cite: 208, 209]。

## セットアップと実行

1.  適切なバージョンの Unity Editor (Unity Hub経由推奨) でこのプロジェクトを開きます。
2.  [cite_start]`Assets/Scenes` フォルダ内のシーンファイル (例: `SampleScene.unity` [cite: 189]) を開きます。
3.  Unity Editor 上部の再生ボタン ▶️ をクリックすると、シミュレーションモードまたは接続されたデバイスでゲームが実行されます。
    * **注意**: Meta Quest 実機で動作させるには、別途 Android ビルド設定と Oculus 連携設定が必要です。

## 作者

* takutaku14 (https://github.com/takutaku14)

---
