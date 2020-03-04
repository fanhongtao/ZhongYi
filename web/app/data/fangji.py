from app.const import const
from app.data.nameditem import NamedItem, load_list


class FangJi(NamedItem):
    def __init__(self):
        super(NamedItem, self).__init__()
        self.fufangs = []
        self.jianbies = []
    
    def parse_xml(self, doc):
        super().parse_xml(doc)
        
        fufangs = doc.getElementsByTagName("附方")
        for fufang in fufangs:
            self.fufangs.append(fufang.childNodes[0].data)
        
        jianbies = doc.getElementsByTagName("鉴别")
        for jianbie in jianbies:
            item = { "fang":[] }
            fangs = jianbie.getElementsByTagName("方名")
            for fang in fangs:
                item["fang"].append(fang.childNodes[0].data)
            item["jianbie"] = jianbie.cloneNode(deep=True)
            self.jianbies.append(item)


def load_fangjis():
    """（程序启动时）加载方剂信息，返回类型为FangJi的列表"""
    return load_list(const.FANGJI_PATH, FangJi)
