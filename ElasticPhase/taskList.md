
- [x] Section 1: Read the introduction to Elasticsearch.
    - [x] Name 3 products of Elastic stack:
        1. Kibana
        1. Logstash
        1. APM
- [x] Section 2: Read architectural benefits and functional features of Elasticsearch.
- [x] Section 3: Understand concepts of Elasticsearch.
- [x] Section 4: Install required tools:
    - [x] Download Elasticsearch.
    - [x] Download Kibana.
    - [x] Run Elasticsearch.
    - [x] Check if Elasticsearch is running opening up [localhost:9200](localhost:9200).
    - [x] Run Kibana.
    - [x] Check if Kibana is running opening up [localhost:5601](localhost:5601).
- [x] Section 5: Create Elasticsearch index:
    - [x] Open up `Dev Tools` in `Kibana`.
    - [x] Run create index query.
- [x] Section 6: Index some documents:
    - [x] Download `people-simple` dataset.
    - [x] Index the dataset into the index created in previous section.
    - [x] Run the query to make sure you've done the job correctly.
- [x] Section 7: Search queries:
    - [x] Run `Match` query.
    - [x] Run `Fuzzy` query.
    - [x] Write down the difference between `Match` and `Fuzzy` queries:
        - مچ دقیقا تطبیق میدهد که همان کلمه بدون هیچ تغییری در مورد ها وجود داشته باشد اما فازی به این صورت است که میتوان کلمات با اختلاف یک کاراکتر طبق قانون لوناشتاین متغیر باشد و اگر عدد فازینس را بیشتر کنیم اختلاف بیشتر یک کاراکتر را نیز نمایش میدهد.
          نکته ای در مورد فازی بود اگر برای سرچ تک کاراکتر بگذاریم با افزایش عدد فازینس بازهم توانایی سرج را نداشت
    - [x] Run `Term` query.
    - [x] What's the difference between `Match` and `Term` queries?
        - مچ همه رکورد هایی که شامل مورد سرچ هستند را میاورد اما ترم باید دقیقا همون کلمه بصورت خاص باشد
    - [x] Run `Range` query.
    - [x] Run `Multi-match` query.
    - [x] What's the difference between `Match` and `Multi-match`?
        - مولتی مچ میتواند چندین فیلد را مورد سرچ قرار دهد اما مچ فقط یک فیلد را سرچ میکند
    - [x] Run `Bool` queries:
        - [x] Run 1st bool query.
        - [x] Run 2nd bool query.
        - [x] Run 3rd bool query.
    - [x] Write down a query in which `name` or `last_name` must be 'Mohammadi' with fuzziness of 1 and `name` should be 'Ali' and age should not be more than 30 (**Hint: You can nest bool queries inside each other**)

```
 GET /people-simple/_search

 {
    "query": {
        "bool": {
            "must": [
                {
                    "multi_match": {
                          "query": "mohammadi",
                          "fields": ["name", "last_name"],
                          "fuzziness": 1
                                   }
                }
            ],
            "should": [
                {
                    "match": {
                        "name": "Ali"
                    }
                }
            ],
            "must_not": [
                {
                                       "range": {
                        "age": {
                           "gt": 30                       
                        }
                    }                          
                }
            ]
        }
    }
}
```

- [x] Section 8: Text analysis: Understand concepts introduced in this section
- [x] Section 9: Text analysis in practice
    - [x] Get mapping of previously created index and pay attention to the default mapping.
    - [x] Run analyze API queries:
        - [x] Run 1st query
        - [x] Run 2nd query
    - [x] Create custom analyzer.
    - [x] Run analyze API query against the custom analyzer.
    - [x] What can be the usage of this custom analyzer?
        - اگر بخواهیم زیررشته‌ی عبارات را جستجو کنیم می‌توانیم از این آنالایزر استفاده کنیم مثلاً اگر عبارت «محمد» را جستجو کنیم و بخواهیم سندی که عبارت «محمدی» دارد نیز در نتایج ظاهر شود.
- [x] Section 10: Search for substrings
    - [x] Define mapping for `last_name` field using the custom analyzer.
    - [x] Run the search query over that field and pay attention to the result.
- [x] Section 11: Other datatypes
    - [x] Download `people` dataset.
    - [x] Create mapping suitable for each field of the dataset.
    - [x] (Optional but recommended) Try out different search queries over fields of different datatypes.


```
PUT people-1
{
    "settings": {
        
        "analysis": {
            "analyzer": {
                "name_analyzer": {
                    "type": "custom",
                    "tokenizer": "standard",
                    "filter": [
                        "lowercase"
                    ]
                },
                "email_analyzer": {
                    "type": "custom",
                    "tokenizer": "email_tokenizer"
                },
                "address_analyzer": {
                    "type": "custom",
                    "tokenizer": "address_tokenizer",
                    "filter": [
                        "lowercase"
                    ]
                },
                "phone_number_analyzer": {
                    "char_filter": "digits_only",
                    "tokenizer": "keyword",
                    "filter": [
                          "digits_min"
                     ]
                },
                "location_latitude": { 
                    "type":"standard",
                    "stopwords": "_latitude_"
                },
                "location_longitude": { 
                    "type":"standard",
                    "stopwords": "_longitude_"
                }
            },
            "tokenizer": {
              "email_tokenizer": {
              "type": "pattern"
            },
            "address_tokenizer": {
              "type": "pattern",
              "pattern": ", "
            }
      },
      "char_filter": {
        "digits_only": {
          "type": "pattern_replace",
          "pattern": "[^\\d]"
        }
      },
      "filter": {
        "digits_min": {
          "type": "length",
          "min": 11
        }
      }
        }
    },
    "mappings": {
        "properties":{
            "age": {
                "type":"integer"
            },
            "eyeColor": {
                "type":"text"
            },
            "name": {
                "type":"text",
                "analyzer":"name_analyzer"
            },
            "gender": {
                "type":"text"
            },
            "company": {
                "type":"text",
                "analyzer":"name_analyzer"
            },
            "email": {
                "type":"text",
                "analyzer":"email_analyzer"
            },
            "phone_number": {
                "type": "text",
                "analyzer" : "phone_number_analyzer"
            },
            "address": {
                "type":"text",
                "analyzer":"address_analyzer"
            },
            "about": {
                "type":"text",
                "analyzer":"name_analyzer"
            },
            "registration_date": {
               "type": "date" ,
                "format": "yyyy/MM/dd HH:mm:ss"
            },
            "location": {
                "type":     "text",
                "analyzer": "standard", 
                "fields": {
                    "latitude": {
                    "type":     "text",
                    "analyzer": "location_latitude" 
                  },
                  "longitude": {
                    "type":     "text",
                    "analyzer": "location_longitude" 
                  }
               }
          }
        }
    }
}

```

- [x] Section 12: Bulk API
    - [x] Download `poems` dataset.
    - [x] Index all the data to Elasticsearch at once using the `Bulk` API. Note that you may need to program some code to create
```
POST poem-test/_bulk
{"index":{}}
{"m1":"چه وعده می‌دهی و چه سوگند می‌خوری","m2":"سوگند و عشوه را تو سپر می‌کنی مکن","poet":"مولوی","url":"https://ganjoor.net/moulavi/shams/ghazalsh/sh2054/"}
{"index":{}}
{"m1":"ز جیب خویش بجو مه چو موسی عمران","m2":"نگر به روزن خویش و بگو سلام سلام","poet":"مولوی","url":"https://ganjoor.net/moulavi/shams/ghazalsh/sh1734/"}
...
```
- [x] Section 13: Aggregations
    - [x] Run the query to get number of poems available from each poet.
    - [x] (Optional) Read about different kinds of aggregation queries and try them out.


```
 {
          "key": "سعدی",
          "doc_count": 1352
        },
        {
          "key": "مولوی",
          "doc_count": 1267
        },
        {
          "key": "فروغی بسطامی",
          "doc_count": 1057
        },
        {
          "key": "محتشم کاشانی",
          "doc_count": 960
        },
        {
          "key": "حافظ",
          "doc_count": 861
        },
        {
          "key": "سلمان ساوجی",
          "doc_count": 592
        },
        {
          "key": "صائب",
          "doc_count": 571
        },
        {
          "key": "عراقی",
          "doc_count": 570
        },
        {
          "key": "امیرخسرو دهلوی",
          "doc_count": 300
        },
        {
          "key": "شهریار",
          "doc_count": 299
        }

```