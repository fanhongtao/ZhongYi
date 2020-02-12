from app.data import zhongyao

class Data:
    def __init__(self):
        self.zhongyaos = zhongyao.load_zhongyaos()
