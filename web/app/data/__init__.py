from app.data import zhongyao
from app.data import fangji

class Data:
    def __init__(self):
        self.zhongyaos = zhongyao.load_zhongyaos()
        self.fangjis = fangji.load_fangjis()
        self.fufang_dict = self.init_fufang_dict()
    
    def init_fufang_dict(self):
        dict = {}
        for fangji in self.fangjis:
            for fufang in fangji.fufangs:
                if fufang in dict:
                    list = dict[fufang]
                else:
                    list = []
                    dict[fufang] = list
                list.append(fangji.name)
        return dict
