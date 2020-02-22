from app.data import zhongyao
from app.data import fangji

class Data:
    def __init__(self):
        self.zhongyaos = zhongyao.load_zhongyaos()
        self.fangjis = fangji.load_fangjis()
