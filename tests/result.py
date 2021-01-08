value = '''{"message":"log_get","logs":[{"data":["Connecting to 127.0.1.100:36412"],"src":"ENB","idx":0,"level":4,"timestamp":63856943,
                                "layer":"S1AP","dir":"- "},{"data":["Connected to 127.0.1.100:36412"],"src":"ENB","idx":1,"level":3,"timestamp":63858446,
                                "layer":"S1AP","dir":"- "},{"data":["127.0.1.100:36412 S1 setup request","initiatingMessage: {","  procedureCode id-S1Setup,","
                                criticality reject,","  value {","    protocolIEs {","      {","        id id-Global-ENB-ID,","        criticality reject,"," 
                                value {","          pLMNidentity '00F110'H,","          eNB-ID macroENB-ID: '1A2D1'H","        }","      },","'
                                {","        id id-eNBname,","        criticality ignore,","        value \"enb1a2d1\"","      },","      {","        id id-SupportedTAs,","
                                criticality reject,","        value {","          {","            tAC '0001'H,","            broadcastPLMNs {","              '00F110'H","            },","
                                iE-Extensions {","              {","                id id-RAT-Type,","                criticality reject,","                extensionValue nbiot","              }
                                ","            }","          },","          {","            tAC '0002'H,","            broadcastPLMNs {","              '00F120'H,","              '00F110'H"," 
                                },","            iE-Extensions {","              {","                id id-RAT-Type,","                criticality reject,","                extensionValue nbiot","
                                }","            }","          }","        }","      },","      {","        id id-DefaultPagingDRX,","        criticality ignore,","        value v32","      },","
                                {","        id id-NB-IoT-DefaultPagingDRX,","        criticality ignore,","        value v128","      }","    }","  }","}",""],"src":"ENB","idx":2,"level":4,"timestamp":63858446,"layer":"S1AP","dir":"TO"}
                                ,{"data":["127.0.1.100:36412 S1 setup response","successfulOutcome: {","  procedureCode id-S1Setup,","  criticality reject,","  value {","    protocolIEs {","      {","        id id-ServedGUMMEIs,","
                                criticality reject,","        value {","          {","            servedPLMNs {","              '00F110'H","            },","            servedGroupIDs {","              '8001'H","            },"," 
                                servedMMECs {","              '01'H","            }","          }","        }","      },","      {","        id id-RelativeMMECapacity,","        criticality ignore,","'
                                value 50","      }","    }","  }","}",""],"src":"ENB","idx":3,"level":4,"timestamp":63858447,"layer":"S1AP","dir":"FROM"}]}'''
print('1')