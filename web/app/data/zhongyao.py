from app.const import const
from app.data.nameditem import NamedItem, load_list


class ZhongYao(NamedItem):
    pass


def load_zhongyaos():
    """（程序启动时）加载中药信息，返回类型为ZhongYao的列表"""
    return load_list(const.ZHONGYAO_PATH, ZhongYao)
