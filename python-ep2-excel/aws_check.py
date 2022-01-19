# 実行前に下のコマンドでインストールが必要
# python3 -m pip install openpyxl requests untangle

import os
import datetime

import openpyxl
import requests
import untangle

url = "https://status.aws.amazon.com/rss/apigateway-ap-northeast-1.rss"
response = requests.get(url)
doc = untangle.parse(response.text)

save_file = 'aws_status.xlsx'

if not os.path.exists(save_file):
    print("file created")
    wb = openpyxl.Workbook()

    sheet = wb.worksheets[0]

    sheet['A1'] = 1 # 追加件数
    sheet['A2'] = datetime.datetime.today()
    sheet['B2'] = doc.rss.channel.ttl.cdata

else:
    print("file updated")
    wb = openpyxl.load_workbook(save_file)
    sheet = wb.worksheets[0]
    count = int(sheet["A1"].value)

    next_row = str(count + 2)
    sheet['A1'] = count + 1 # 追加件数
    sheet['A' + next_row] = datetime.datetime.today()
    sheet['B' + next_row] = doc.rss.channel.ttl.cdata

wb.save(save_file)
wb.close()




