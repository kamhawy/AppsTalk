using ABATS.AppsTalk.Adapters.WincashWSAdapter.MaterialInterfaceReference;
using ABATS.AppsTalk.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace ABATS.AppsTalk.Adapters.WincashWSAdapter
{
    /// <summary>
    /// WincashWSAdapter Utilities
    /// </summary>
    internal static class WincashWSAdapterUtilities
    {
        #region Builders

        /// <summary>
        /// Build Standard Material Object
        /// </summary>
        /// <param name="pDBRecord"></param>
        /// <returns></returns>
        internal static standardMaterial BuildStandardMaterialObject(DBRecordInfo pDBRecord, WincashWSAdapterConfig pWincashWSAdapterConfig)
        {
            standardMaterial material = null;

            try
            {
                if (pDBRecord == null || pDBRecord.Row == null)
                    return null;

                material = new standardMaterial()
                {
                    materialNumber = pDBRecord.GetFieldValue<String>(QueryFields.materialNumber)
                };

                DateTime modificationStamp = WincashWSAdapterUtilities.ParseModificationStamp(
                    pDBRecord.GetFieldValue<String>(QueryFields.modificationStamp));

                if (modificationStamp != DateTime.MinValue)
                {
                    material.modificationStamp = modificationStamp;
                    material.modificationStampSpecified = true;
                }

                if (!material.materialNumber.IsValidString())
                    return null;

                #region Master Data Settings

                material.masterDataSettings = new masterDataSettings()
                {
                    status = pDBRecord.GetFieldValue<String>(QueryFields.status).ToStatus(),
                    statusSpecified = true
                };

                #endregion

                #region Inheritance Settings

                material.inheritanceSettings = new inheritanceSettings()
                {
                    Item = pDBRecord.GetFieldValue<String>(QueryFields.treeID), // [shopName or treeID]
                    ItemElementName = ItemChoiceType.treeID
                };

                #endregion

                #region General Settings

                // Material Name Translations 
                List<translation> _materialNameTranslations = new List<translation>();
                _materialNameTranslations.Add(new translation()
                {
                    translatedLanguage = "EN",
                    translatedText = pDBRecord.GetFieldValue<String>(QueryFields.materialName)
                });
                List<translation> _materialName2Translations = new List<translation>();
                _materialName2Translations.Add(new translation()
                {
                    translatedLanguage = "EN",
                    translatedText = pDBRecord.GetFieldValue<String>(QueryFields.materialName2)
                });

                material.generalSettings = new generalSettings()
                {
                    materialName = pDBRecord.GetFieldValue<String>(QueryFields.materialName),
                    materialNameTranslations = _materialNameTranslations.ToArray(),
                    materialName2 = pDBRecord.GetFieldValue<String>(QueryFields.materialName2),
                    materialName2Translations = _materialName2Translations.ToArray(),
                    Item = pDBRecord.GetFieldValue<String>(QueryFields.goodsGroupName),
                    ItemElementName = ItemChoiceType3.goodsGroupName,
                    Item1 = pDBRecord.GetFieldValue<String>(QueryFields.materialGroupName),
                    Item1ElementName = Item1ChoiceType2.materialGroupName,
                    Item2 = pDBRecord.GetFieldValue<String>(QueryFields.unitName),
                    Item2ElementName = Item2ChoiceType.unitName,
                    supplierMaterialNumber = pDBRecord.GetFieldValue<String>(QueryFields.supplierMaterialNumber)
                };

                #endregion

                #region Price Settings

                material.priceSettings = new priceSettings()
                {
                    price = pDBRecord.BuildNonFractionNumber(QueryFields.price, QueryFields.priceMultiplier),
                    Item = pDBRecord.GetFieldValue<String>(QueryFields.currencyName), // [currencyID or currencyName]
                    ItemElementName = ItemChoiceType4.currencyName,
                    Item1 = pDBRecord.GetFieldValue<String>(QueryFields.taxNumber), // [taxID or taxNumber]
                    Item1ElementName = Item1ChoiceType9.taxNumber,
                    denyPriceOverwriting = pDBRecord.GetFieldValue<String>(QueryFields.denyPriceOverwriting).ToFlag(),
                    denyPriceOverwritingSpecified = true,
                    denyReduction = pDBRecord.GetFieldValue<String>(QueryFields.denyReduction).ToFlag(),
                    denyReductionSpecified = true,
                    allowNegativeReducedPrice = pDBRecord.GetFieldValue<String>(QueryFields.allowNegativeReducedPrice).ToFlag(),
                    allowNegativeReducedPriceSpecified = true,
                    maximumPrice = pDBRecord.BuildNonFractionNumber(QueryFields.maximumPriceValue, QueryFields.maximumPriceMultiplier),
                    minimumPrice = pDBRecord.BuildNonFractionNumber(QueryFields.minimumPriceValue, QueryFields.minimumPriceMultiplier),
                    turnoverRelevancy = pDBRecord.BuildNonFractionNumber(QueryFields.turnoverRelevancyValue, QueryFields.turnoverRelevancyMultiplier),
                    priceListsAvailable = pDBRecord.GetFieldValue<String>(QueryFields.priceListsAvailable).ToFlag(),
                    priceListsAvailableSpecified = true
                };

                #endregion

                #region Serial Settings

                List<serialNumberDefinition> _serialNumberDefinitions = new List<serialNumberDefinition>();
                _serialNumberDefinitions.Add(new serialNumberDefinition()
                {
                    serialLength = pDBRecord.GetFieldValue<String>(QueryFields.serialLength),
                    serialType = pDBRecord.GetFieldValue<String>(QueryFields.serialType).ToSerialType(),
                    serialTypeSpecified = true
                });

                material.serialSettings = new serialSettings()
                {
                    forceSerial = pDBRecord.GetFieldValue<String>(QueryFields.forceSerial).ToFlag(),
                    forceSerialSpecified = true,
                    serialPoolTracked = pDBRecord.GetFieldValue<String>(QueryFields.serialPoolTracked).ToFlag(),
                    serialPoolTrackedSpecified = true,
                    serialNumberDefinitions = _serialNumberDefinitions.ToArray()
                };

                #endregion

                #region Inventory Handling

                material.inventoryHandling = new inventoryHandling()
                {
                    inventoryAssignments = WincashWSAdapterUtilities.BuildMaterialToStockMappingList(pDBRecord, pWincashWSAdapterConfig),
                    supplierAssignments = WincashWSAdapterUtilities.BuildMaterialToSupplierList(pDBRecord, pWincashWSAdapterConfig),
                    valuationPrice = pDBRecord.BuildNonFractionNumber(QueryFields.valuationPriceValue, QueryFields.valuationPriceMultiplier),
                    // Flags
                    stockControl = pDBRecord.GetFieldValue<String>(QueryFields.stockControl).ToFlag(),
                    stockControlSpecified = true,
                    denyAutomaticOrder = pDBRecord.GetFieldValue<String>(QueryFields.denyAutomaticOrder).ToFlag(),
                    denyAutomaticOrderSpecified = true,
                    denyNegativeStockQuantity = pDBRecord.GetFieldValue<String>(QueryFields.denyNegativeStockQuantity).ToFlag(),
                    denyNegativeStockQuantitySpecified = true
                };

                #endregion

                #region Extended Settings

                List<translation> _materialDescriptionTranslations = new List<translation>();
                _materialDescriptionTranslations.Add(new translation()
                {
                    translatedLanguage = "EN",
                    translatedText = pDBRecord.GetFieldValue<String>(QueryFields.materialDescription)
                });

                material.extendedSettings = new extendedSettings()
                {
                    usageSettings = new usageSettings()
                    {
                        allowQuantityOverwriting = pDBRecord.GetFieldValue<String>(QueryFields.allowQuantityOverwriting).ToFlag(),
                        allowQuantityOverwritingSpecified = true,
                        rejectionReason = pDBRecord.GetFieldValue<String>(QueryFields.rejectionReason).ToFlag(),
                        rejectionReasonSpecified = true,
                        isUseUserItemRestriction = pDBRecord.GetFieldValue<String>(QueryFields.isUseUserItemRestriction).ToFlag(),
                        isUseUserItemRestrictionSpecified = true
                    },
                    extendedMaterialDescription = new extendedMaterialDescription()
                    {
                        materialDescription = pDBRecord.GetFieldValue<String>(QueryFields.materialDescription),
                        materialDescriptionTranslations = _materialDescriptionTranslations.ToArray(),
                        hyperlink = pDBRecord.GetFieldValue<String>(QueryFields.hyperlink),
                        materialPicture = pDBRecord.GetFieldValue<String>(QueryFields.materialPicture)
                    },
                    leaseSettings = new leaseSettings()
                    {
                        denyLeaseExchange = pDBRecord.GetFieldValue<String>(QueryFields.denyLeaseExchange).ToFlag(),
                        denyLeaseExchangeSpecified = true
                    },
                    reservationSettings = new reservationSettings()
                    {
                        denyReservation = pDBRecord.GetFieldValue<String>(QueryFields.denyReservation).ToFlag(),
                        denyReservationSpecified = true
                    }
                };

                #endregion
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return material;
        }

        /// <summary>
        /// Build Restricted Payment IDs
        /// </summary>
        /// <param name="sRestrictedPaymentIDs"></param>
        /// <returns></returns>
        internal static restrictedPaymentIDs BuildRestrictedPaymentIDs(string sRestrictedPaymentIDs)
        {
            restrictedPaymentIDs _restrictedPaymentIDs = null;

            if (sRestrictedPaymentIDs.IsValidString())
            {
                _restrictedPaymentIDs = new restrictedPaymentIDs()
                {
                    paymentID = sRestrictedPaymentIDs.Split(',')
                };
            }

            return _restrictedPaymentIDs;
        }

        /// <summary>
        /// Build Unique ID
        /// </summary>
        /// <returns></returns>
        internal static string BuildUniqueID()
        {
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddhhmmss"), DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Build Failed Material List
        /// </summary>
        /// <param name="pGenericImportResponse"></param>
        /// <returns></returns>
        internal static IList<string> BuildFailedMaterialList(genericImportResponse pGenericImportResponse)
        {
            IList<string> _failedMaterialList = new List<string>();

            try
            {
                foreach (processedJob _job in pGenericImportResponse.jobs)
                {
                    foreach (failedRecord _failedRecord in _job.failedRecords.Where(c => c.keyValues.Length > 0))
                    {
                        string failedMaterialNumber = string.Empty;

                        foreach (keyValue failedKeyValue in _failedRecord.keyValues)
                        {
                            if (failedKeyValue.keyName.IsValidString() &&
                                failedKeyValue.keyName.ToLower().Trim() == QueryFields.materialNumber.ToLower().Trim())
                            {
                                failedMaterialNumber = failedKeyValue.Value;
                                break;
                            }
                        }

                        if (failedMaterialNumber.IsValidString())
                        {
                            _failedMaterialList.Add(failedMaterialNumber);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return _failedMaterialList;
        }

        /// <summary>
        /// Build Material To Stock Mapping List
        /// </summary>
        /// <param name="pDBRecord"></param>
        /// <param name="pWincashWSAdapterConfig"></param>
        /// <returns></returns>
        internal static materialToStockMapping[] BuildMaterialToStockMappingList(DBRecordInfo pDBRecord, WincashWSAdapterConfig pWincashWSAdapterConfig)
        {
            List<materialToStockMapping> materialToStockMappings = null;

            try
            {
                string sStockMapping = pDBRecord.GetFieldValue<String>(QueryFields.stockMapping);

                if (!sStockMapping.IsValidString())
                    return null;

                string[] stocksParts = sStockMapping.Split(pWincashWSAdapterConfig.StockMappingMainSplitter);

                foreach (string sStock in stocksParts)
                {
                    try
                    {
                        string[] stockItemParts = sStock.Split(pWincashWSAdapterConfig.StockMappingInnerSplitter);

                        if (stockItemParts != null && stockItemParts.Length == 8)
                        {
                            if (materialToStockMappings == null)
                            {
                                materialToStockMappings = new List<materialToStockMapping>();
                            }

                            materialToStockMappings.Add(new materialToStockMapping()
                            {
                                Item1 = stockItemParts[0], //stockName
                                Item1ElementName = Item1ChoiceType7.stockName,
                                isStandard = stockItemParts[1].ToFlag(), //isStandard
                                masterDataSettings = new masterDataSettings()
                                {
                                    status = stockItemParts[2].ToStatus(), //status
                                    statusSpecified = true
                                },
                                usageSettings = new stockUsageSettings()
                                {
                                    showSale = stockItemParts[3].ToFlag(), //showSale
                                    showSaleSpecified = true,
                                    showReturn = stockItemParts[4].ToFlag(), //showReturn
                                    showReturnSpecified = true,
                                    showOrder = stockItemParts[5].ToFlag(), //showOrder
                                    showOrderSpecified = true,
                                    showLeaseOut = stockItemParts[6].ToFlag(), //showLeaseOut
                                    showLeaseOutSpecified = true,
                                    showLeaseIn = stockItemParts[7].ToFlag(), //showLeaseIn
                                    showLeaseInSpecified = true
                                }
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        LogManager.LogException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return materialToStockMappings != null ? materialToStockMappings.ToArray() : null;
        }

        /// <summary>
        /// Build Material To Supplier Mapping List
        /// </summary>
        /// <param name="pDBRecord"></param>
        /// <param name="pWincashWSAdapterConfig"></param>
        /// <returns></returns>
        internal static materialToSupplier[] BuildMaterialToSupplierList(DBRecordInfo pDBRecord, WincashWSAdapterConfig pWincashWSAdapterConfig)
        {
            List<materialToSupplier> materialToSupplierMappings = null;

            try
            {
                string supplierName = pDBRecord.GetFieldValue<String>(QueryFields.supplierName);

                if (!supplierName.IsValidString())
                    return null;

                materialToSupplierMappings = new List<materialToSupplier>();

                // Only one materialToSupplierMappings is considered
                materialToSupplierMappings.Add(new materialToSupplier()
                {
                    Item1 = pDBRecord.GetFieldValue<String>(QueryFields.supplierName), //[supplierID or supplierName] 
                    Item1ElementName = Item1ChoiceType6.supplierName,
                    defaultSupplier = pDBRecord.GetFieldValue<String>(QueryFields.defaultSupplier).ToFlag(),
                    deliveryTime = pDBRecord.GetFieldValue<String>(QueryFields.deliveryTime),
                    priceSettings = new supplierPriceSettings()
                    {
                        averageCostPrice = pDBRecord.BuildNonFractionNumber(QueryFields.averageCostPriceValue, QueryFields.averageCostPriceMultiplier),
                        costPrice = pDBRecord.BuildNonFractionNumber(QueryFields.costPriceValue, QueryFields.costPriceMultiplier),
                        Item = pDBRecord.GetFieldValue<String>(QueryFields.currencyName), //[currencyID or currencyName]
                        ItemElementName = ItemChoiceType10.currencyName
                    },
                    quantitySettings = new supplierQuantitySettings()
                    {
                        maximumQuantity = pDBRecord.BuildNonFractionNumber(QueryFields.maximumQuantityValue, QueryFields.maximumQuantityMultiplier),
                        minimumQuantity = pDBRecord.BuildNonFractionNumber(QueryFields.minimumQuantityValue, QueryFields.minimumQuantityMultiplier),
                        quantityMultiplier = pDBRecord.BuildNonFractionNumber(QueryFields.quantityMultiplier, QueryFields.quantityMultiplierMultiplier),
                        Item = pDBRecord.GetFieldValue<String>(QueryFields.unitName), //[unitID or unitName]
                        ItemElementName = ItemChoiceType11.unitName
                    }
                });
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return materialToSupplierMappings != null ? materialToSupplierMappings.ToArray() : null;
        }

        /// <summary>
        /// Build Goods Group List
        /// </summary>
        /// <param name="pDBRecords"></param>
        /// <returns></returns>
        internal static goodsGroupList BuildGoodsGroupList(List<DBRecordInfo> pDBRecords)
        {
            goodsGroupList _goodsGroupList = null;

            try
            {
                if (pDBRecords != null && pDBRecords.Count > 0)
                {
                    List<goodsGroup> _goodsGroups = new List<goodsGroup>();

                    foreach (DBRecordInfo dbRecord in pDBRecords)
                    {
                        string _goodsGroupName = dbRecord.GetFieldValue<String>(QueryFields.goodsGroupName);

                        if (_goodsGroupName.IsValidString())
                        {
                            goodsGroup _goodsGroup = _goodsGroups.FirstOrDefault(c => c.goodsGroupName == _goodsGroupName);

                            if (_goodsGroup == null)
                            {
                                _goodsGroup = new goodsGroup()
                                {
                                    goodsGroupName = _goodsGroupName,
                                    description = dbRecord.GetFieldValue<String>(QueryFields.goodsGroupDescription),
                                    masterDataSettings = new masterDataSettings()
                                    {
                                        status = dbRecord.GetFieldValue<String>(QueryFields.goodsGroupStatus).ToStatus(),
                                        statusSpecified = true
                                    },
                                    inheritanceSettings = new inheritanceSettings()
                                    {
                                        Item = dbRecord.GetFieldValue<String>(QueryFields.treeID), // [shopName or treeID]
                                        ItemElementName = ItemChoiceType.treeID,
                                        parentID = "-1"
                                    },
                                    hierarchySettings = new groupHierarchySettings()
                                    {
                                        Item = "-1",
                                        ItemElementName = ItemChoiceType2.treeParentID,
                                        treeLev = "0"
                                    },
                                    customValues = new List<customValue>().ToArray()
                                };

                                DateTime modificationStamp = WincashWSAdapterUtilities.ParseModificationStamp(
                                    dbRecord.GetFieldValue<String>(QueryFields.modificationStamp));

                                if (modificationStamp != DateTime.MinValue)
                                {
                                    _goodsGroup.modificationStamp = modificationStamp;
                                    _goodsGroup.modificationStampSpecified = true;
                                }

                                _goodsGroups.Add(_goodsGroup);
                            }
                        }
                    }

                    if (_goodsGroups.Count > 0)
                    {
                        _goodsGroupList = new goodsGroupList()
                        {
                            transferMode = dataTransferMode.DELTA,
                            transferModeSpecified = true,
                            goodsGroup = _goodsGroups.ToArray()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return _goodsGroupList;
        }

        /// <summary>
        /// Build Material Group List
        /// </summary>
        /// <param name="pDBRecords"></param>
        /// <returns></returns>
        internal static materialGroupList BuildMaterialGroupList(List<DBRecordInfo> pDBRecords)
        {
            materialGroupList _materialGroupList = null;

            try
            {
                if (pDBRecords != null && pDBRecords.Count > 0)
                {
                    List<materialGroup> _materialGroups = new List<materialGroup>();

                    foreach (DBRecordInfo dbRecord in pDBRecords)
                    {
                        string _materialGroupName = dbRecord.GetFieldValue<String>(QueryFields.materialGroupName);

                        if (_materialGroupName.IsValidString())
                        {
                            materialGroup _materialGroup = _materialGroups.FirstOrDefault(c => c.materialGroupName == _materialGroupName);

                            if (_materialGroup == null)
                            {
                                _materialGroup = new materialGroup()
                                {
                                    materialGroupName = _materialGroupName,
                                    description = dbRecord.GetFieldValue<String>(QueryFields.materialGroupDescription),
                                    isUseUserItemGroupRestriction = dbRecord.GetFieldValue<String>(QueryFields.isUseUserItemGroupRestriction).ToFlag(),
                                    isUseUserItemGroupRestrictionSpecified = true,
                                    masterDataSettings = new masterDataSettings()
                                    {
                                        status = dbRecord.GetFieldValue<String>(QueryFields.materialGroupStatus).ToStatus(),
                                        statusSpecified = true
                                    },
                                    inheritanceSettings = new inheritanceSettings()
                                    {
                                        Item = dbRecord.GetFieldValue<String>(QueryFields.treeID), // [shopName or treeID]
                                        ItemElementName = ItemChoiceType.treeID,
                                        parentID = "-1"
                                    },
                                    hierarchySettings = new groupHierarchySettings()
                                    {
                                        Item = "-1", //TODO: Read from the view
                                        ItemElementName = ItemChoiceType2.treeParentID,
                                        treeLev = "0"
                                    },
                                    customValues = new List<customValue>().ToArray()
                                };

                                DateTime modificationStamp = WincashWSAdapterUtilities.ParseModificationStamp(
                                    dbRecord.GetFieldValue<String>(QueryFields.modificationStamp));

                                if (modificationStamp != DateTime.MinValue)
                                {
                                    _materialGroup.modificationStamp = modificationStamp;
                                    _materialGroup.modificationStampSpecified = true;
                                }

                                _materialGroups.Add(_materialGroup);
                            }
                        }
                    }

                    if (_materialGroups.Count > 0)
                    {
                        _materialGroupList = new materialGroupList()
                        {
                            transferMode = dataTransferMode.DELTA,
                            transferModeSpecified = true,
                            materialGroup = _materialGroups.ToArray()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return _materialGroupList;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDBValue"></param>
        /// <returns></returns>
        internal static DateTime ParseModificationStamp(string pDBValue)
        {
            DateTime returnDate = DateTime.MinValue;

            if (pDBValue.IsValidString())
            {
                string format = "dd/MM/yyyy h:mm tt"; //Example: 16/07/2008 8:30 AM "

                if (!DateTime.TryParseExact(pDBValue, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out returnDate))
                {
                    returnDate = DateTime.MinValue;
                }
            }

            return returnDate;
        }

        #endregion
    }

    /// <summary>
    /// Extensions
    /// </summary>
    internal static class Extensions
    {
        #region Extensions

        /// <summary>
        /// To Flag
        /// </summary>
        /// <param name="pBoolean"></param>
        /// <returns></returns>
        internal static flag ToFlag(this Boolean pBoolean)
        {
            return pBoolean ? flag.Yes : flag.No;
        }

        /// <summary>
        /// To Flag
        /// </summary>
        /// <param name="pString"></param>
        /// <returns></returns>
        internal static flag ToFlag(this String pString)
        {
            return pString.IsValidString() ? (pString.ToLower() == "y" ? flag.Yes : flag.No) : flag.No;
        }

        /// <summary>
        /// To Serial Type
        /// </summary>
        /// <param name="pSerialType"></param>
        /// <returns></returns>
        internal static serialType ToSerialType(this String pSerialType)
        {
            serialType _serialType = serialType.NONE;

            if (pSerialType.IsValidString())
            {
                string _compareValue = pSerialType.ToLower();

                switch (_compareValue)
                {
                    case "sim":
                        {
                            _serialType = serialType.SIM;
                        }
                        break;
                    case "cash":
                        {
                            _serialType = serialType.CASH;
                        }
                        break;
                    case "imei":
                        {
                            _serialType = serialType.IMEI;
                        }
                        break;
                    case "rand":
                        {
                            _serialType = serialType.RAND;
                        }
                        break;
                    case "cons":
                        {
                            _serialType = serialType.CONS;
                        }
                        break;
                    case "7812":
                    case "item7812":
                        {
                            _serialType = serialType.Item7812;
                        }
                        break;
                    case "ean13":
                        {
                            _serialType = serialType.EAN13;
                        }
                        break;
                    case "none":
                    default:
                        {
                            _serialType = serialType.NONE;
                        }
                        break;
                }
            }

            return _serialType;
        }

        /// <summary>
        /// Parse Status
        /// </summary>
        /// <param name="sStatus"></param>
        /// <returns></returns>
        internal static status ToStatus(this String sStatus)
        {
            status _status = status.A;

            if (sStatus.IsValidString())
            {
                string _compareValue = sStatus.ToLower();

                switch (_compareValue)
                {
                    case "d":
                        {
                            _status = status.D;
                        }
                        break;
                    case "i":
                        {
                            _status = status.I;
                        }
                        break;
                    case "a":
                    default:
                        {
                            _status = status.A;
                        }
                        break;
                }
            }

            return _status;
        }

        /// <summary>
        /// To Item Choice Type
        /// </summary>
        /// <param name="pItemChoiceType"></param>
        /// <returns></returns>
        internal static ItemChoiceType19 ToItemChoiceType19(this String pItemChoiceType)
        {
            ItemChoiceType19 _ItemChoiceType = ItemChoiceType19.accountName;

            if (pItemChoiceType.IsValidString())
            {
                string _compareValue = pItemChoiceType.ToLower();

                switch (_compareValue)
                {
                    case "accountname":
                    default:
                        {
                            _ItemChoiceType = ItemChoiceType19.accountName;
                        }
                        break;
                    case "accountid":
                        {
                            _ItemChoiceType = ItemChoiceType19.accountID;
                        }
                        break;
                    case "accountnumber":
                        {
                            _ItemChoiceType = ItemChoiceType19.accountNumber;
                        }
                        break;
                }
            }

            return _ItemChoiceType;
        }

        /// <summary>
        /// Build NonFraction Number
        /// </summary>
        /// <param name="pDbRecordInfo"></param>
        /// <param name="pValueFieldName"></param>
        /// <param name="pMultiplierFieldName"></param>
        /// <returns></returns>
        internal static nonFractionNumber BuildNonFractionNumber(this DBRecordInfo pDbRecordInfo, string pValueFieldName, string pMultiplierFieldName = "")
        {
            return new nonFractionNumber()
            {
                Value = pDbRecordInfo.GetFieldValue<String>(pValueFieldName),
                multiplier = pMultiplierFieldName.IsValidString() ?
                    pDbRecordInfo.GetFieldValue<String>(pMultiplierFieldName) : "1"
            };
        }

        /// <summary>
        /// To Quantity Calculation Type
        /// </summary>
        /// <param name="pQuantityCalculationType"></param>
        /// <returns></returns>
        internal static quantityCalculationType ToQuantityCalculationType(this String pQuantityCalculationType)
        {
            quantityCalculationType _quantityCalculationType = quantityCalculationType.MAXMIN;

            if (pQuantityCalculationType.IsValidString())
            {
                string _compareValue = pQuantityCalculationType.ToLower();

                switch (_compareValue)
                {
                    case "maxwarn":
                        {
                            _quantityCalculationType = quantityCalculationType.MAXWARN;
                        }
                        break;
                    case "reqmin":
                        {
                            _quantityCalculationType = quantityCalculationType.REQMIN;
                        }
                        break;
                    case "reqwarn":
                        {
                            _quantityCalculationType = quantityCalculationType.REQWARN;
                        }
                        break;
                    case "maxmin":
                    default:
                        {
                            _quantityCalculationType = quantityCalculationType.MAXMIN;
                        }
                        break;
                }
            }

            return _quantityCalculationType;
        }

        #endregion
    }

    /// <summary>
    /// Wincash WS Adapter Config
    /// </summary>
    internal class WincashWSAdapterConfig
    {
        #region Properties

        internal string SecurityTokenUserName { get; set; }

        internal string SecurityTokenPassword { get; set; }

        internal string InterfaceVersion { get; set; }

        internal string BuildNumber { get; set; }

        internal string SenderID { get; set; }

        internal char StockMappingMainSplitter { get; set; }

        internal char StockMappingInnerSplitter { get; set; }

        #endregion

        #region Constructor

        internal WincashWSAdapterConfig()
        {
            this.BuildConfigurations();
        }

        #endregion

        #region Methods

        private void BuildConfigurations()
        {
            this.SecurityTokenUserName = ConfigurationManager.AppSettings["SecurityTokenUserName"];
            this.SecurityTokenPassword = ConfigurationManager.AppSettings["SecurityTokenPassword"];
            this.InterfaceVersion = ConfigurationManager.AppSettings["InterfaceVersion"];
            this.BuildNumber = ConfigurationManager.AppSettings["BuildNumber"];
            this.SenderID = ConfigurationManager.AppSettings["SenderID"];
            string _StockMappingMainSplitter = ConfigurationManager.AppSettings["StockMappingMainSplitter"];
            this.StockMappingMainSplitter = (_StockMappingMainSplitter.IsValidString() && _StockMappingMainSplitter.Length == 1) ?
                _StockMappingMainSplitter[0] : '$';
            string _StockMappingInnerSplitter = ConfigurationManager.AppSettings["StockMappingInnerSplitter"];
            this.StockMappingInnerSplitter = (_StockMappingInnerSplitter.IsValidString() && _StockMappingInnerSplitter.Length == 1) ?
                _StockMappingInnerSplitter[0] : '|';
        }

        #endregion
    }
}