# billiards  
制作期間　2日  
白いボールを打って色付きのボールを穴に入れるゲーム。
Resetボタンを押すことで初期位置に戻し、スコアを０に戻せる。
スコアは色付きのボールが落ちると+1,白色のボールが落ちたとき-1される。
白いボールが落ちたとき白のボールの初期位置に戻る。

開発過程  
とにかく何か作ってみようと思いビリヤードゲームを参考サイト[1]を元に作成。
白い球が落ちても戻ってこなかったので白い球が落ちた時の例外処理を実装し初期位置に戻るように設定。
スコアがあった方がやりがいがあると思ったのでScoreのためのスクリプトを作成。
リセットされた時にスコアもリセットされるように設定。

参考　　
[1]https://feynman.co.jp/unityforest/unity-introduction/billiard-making/
