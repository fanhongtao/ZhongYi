from app.const import const
from app.data.nameditem import NamedItem, load_list


class FangJi(NamedItem):
    pass


def load_fangjis():
    """（程序启动时）加载方剂信息，返回类型为FangJi的列表"""
    return load_list(const.FANGJI_PATH, FangJi)
