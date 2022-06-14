using LaborPro.Automation.shared.drivers;
using LaborPro.Automation.shared.hooks;
using LaborPro.Automation.shared.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LaborPro.Automation.Features.Standards
{
    public class StandardsPage
    {
        private const string StandardsTab = "//a[@href='/standards']";
        private const string StandardPageTitle = "//h3[contains(text(),'Standards')]";
        private const string CloseStandardsFormButton = "//*[@class='modal-dialog']//button[contains(text(),'Cancel')]";
        private const string ErrorAlertToastXpath = "//*[@class='toast toast-error']";
        private const string NameInput = "//*[@id='name']";
        private const string SaveButton = "//button[contains(text(),'Save')]";
        private const string DepartmentInput = "//select[@id='departmentId']";
        private const string AddStandardButton = "//button[.//*[@class='fa fa-plus']]";
        private const string NewStandard = "//a[contains(text(),'New Standard')]";
        private const string NameTagInputInEditForm = "//input[@value='{0}']";
        private const string OpenEditSidebarForm = "//*[@class='sidebar-scrollable']//div[@class='form-group']";
        private const string EditButtonSidebar = "//button//strong[contains(text(),'edit')]";
        private const string DeleteButton = "//button//i[contains(@title,'Delete')]";
        private const string ConfirmPopupButton = "//button[contains(text(),'Confirm')]";
        private const string NewStandardElement = "//*[@class='add-standard-item standalone']//button[@title='New Standard Element']";
        private const string NewStandardElementPopup = "//*[@role='dialog']//h4[contains(text(),'{0}')]";
        private const string PageTitle = "//*[@class='page-title']";
        private const string StandardElementDropdown = "//select[@id='standardElementType']";
        private const string StandardElementPopup = "//*[@role='dialog']//h4[contains(text(),'Select Standard Element Type')]";
        private const string StandardByName = "//*[@role='row' and .//*[text()='{0}']]";
        private const string StandardDetailsSidebar = "//*[@class='sidebar standard-profile']";
        private const string StandardElementDropdownButton = "//*[@class='content']//button[@class='dropdown-toggle btn btn-link']";
        private const string StandardElementDeleteButton = "//*[@role='presentation']//a[contains(text(),'Delete')]";
        private const string StandardSidebar = "//*[@class='page-header']//button[@class='btn-wheat btn btn-default']//i";
        private const string StandardElementConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ConfirmPopup = "//*[@class='modal-dialog']//*[contains(text(),'Please confirm that you want to delete')]";
        private const string ConfirmButton = "//*[@class='modal-content']//button[text()='Confirm']";
        private const string StandardElementNameTag = "//*[@class='form-group']//input[@name='name']";
        private const string StandardElementFrequencyTag = "//*[@class='form-group']//input[@name='frequencyFormula']";
        private const string StandardElementUomTag = "//select[@id='unitOfMeasureId']";
        private const string CreatedStandardElement = "//*[@class='content']//span[contains(text(),'{0}')]";
        private const string StandardElementContent = "//*[@class='content']";
        private const string StandardElementOkButton = "//*[@class='modal-dialog']//button[contains(text(),'OK')]";
        private const string StandardFilterInput = "//*[@aria-label='Filter' and @aria-colindex='{0}']//input";
        private const string PageLoader = "//*[@title='Submission in progress']";
        private const string ClearFilterButton = "//button[@title='Clear All Filters']";
        private const string StandardElementFrequencyAlert = "//*[@class='form-group has-error']";
        private const string NewStandardElementForm = "//*[@role='dialog']//h4[contains(text(),'New Estimate')]";
        private const string StandardElementUomValueInDropdown = "//*[@id='unitOfMeasureId']//option[contains(text(),'{0}')]";
        private const string StandardDetailsSidebarButton = "//*[@class='page-header']//button[@class='btn-default btn btn-default']//i";
        private const string StandardElementTimeTag = "//*[@class='form-group']//input[@id='measuredTimeMeasurementUnits']";
        private const string StandardForm = "//*[@role='dialog']//*[@class='modal-title' and contains(text(),'New Standard')]";
        private const string AttributeInput = "//select[@id='attributeId']";
        private const string Name = "Name";
        private const string StandardTableHeader = "//table[@role='presentation']//th//*[@class='k-link']";
        private const string FormInputFieldErrorXpath = "//*[contains(@class,'validation-error')]";
        private const string StandardRecord = "//*[@role='row' and .//*[text()='{0}']]";
        private const string ElementAlert = "//*[@class='form-group has-error']";

        public static void ClickOnStandardsTab()
        {
            LogWriter.WriteLog("Executing StandardPage.ClickOnStandardsTab");
            if (WebDriverUtil.GetWebElement(StandardPageTitle, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(StandardsTab, WebDriverUtil.DEFAULT_WAIT, $"Unable to locate the standard tab - {StandardsTab}").Click();
                WebDriverUtil.WaitForAWhile();
            }
        }
        public static void CloseStandardsForm()
        {
            LogWriter.WriteLog("Executing StandardPage.CloseStandardsForm");
            WaitForStandardsAlertCloseIfAny();
            IWebElement formCloseButton = WebDriverUtil.GetWebElement(CloseStandardsFormButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (formCloseButton != null)
            {
                formCloseButton.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void WaitForStandardsAlertCloseIfAny()
        {
            LogWriter.WriteLog("Executing StandardPage.WaitForAllowanceAlertCloseIfAny");
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert != null)
            {
                IWebElement nameTag = WebDriverUtil.GetWebElementAndScroll(NameInput);
                if (nameTag != null)
                {
                    nameTag.Click();
                }
                WebDriverUtil.WaitForWebElementInvisible(ErrorAlertToastXpath, WebDriverUtil.TEN_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
        }
        public static void ClickOnAddStandards()
        {
            LogWriter.WriteLog("Executing StandardPage.ClickOnAddStandards");
            IWebElement AddStandard = WebDriverUtil.GetWebElement(AddStandardButton, WebDriverUtil.NO_WAIT,
                $"Unable to Locate Add Standard Button - {AddStandardButton}");
            IWebElement NewStandard = WebDriverUtil.GetWebElement(StandardsPage.NewStandard, WebDriverUtil.NO_WAIT,
                $"Unable to locate the New Standard Button - {StandardsPage.NewStandard}");
            if (AddStandard != null || NewStandard != null)
            {
                AddStandard.Click();
                NewStandard.Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);

            }

        }
        public static void AddStandardsWihGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing StandardPage.AddStandardWithGivenInput");
            ClickOnAddStandards();
            WaitForStandardsAlertCloseIfAny();
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(NameInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input on create standard page - {NameInput}").SendKeys(dictionary["Name"]);
            }

            if (Util.ReadKey(dictionary, "Department") != null)
            {
               new SelectElement( WebDriverUtil.GetWebElement(DepartmentInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate DEPARTMENT input on create standard page - {DepartmentInput}")).SelectByText(dictionary["Department"]);
               
            }

            if(Util.ReadKey(dictionary, "Attribute") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(AttributeInput, WebDriverUtil.NO_WAIT,
                    $"Unable to locate Attribute input on create standard page - {AttributeInput}")).SelectByText(dictionary["Attribute"]);
            }



            WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate Save Button- {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Saving...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);

            if (WebDriverUtil.GetWebElement(StandardForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(StandardForm, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception($"Unable to create new Standard Error - {alert.Text}");
                        }
                    }
                }
            }
           
        }
        public static void VerifyCreatedStandard(string standardName)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyCreatedStandard");
            IWebElement standardValueInEditForm = WebDriverUtil.GetWebElement(String.Format(NameTagInputInEditForm, standardName), WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardValueInEditForm == null)
            {
                standardValueInEditForm = WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception($"We supposed to get StandardPage tile - {standardName} but found - {standardValueInEditForm.Text}" );
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteCreatedStandard()
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteCreatedStandard ");
            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(StandardDetailsSidebarButton, 
                WebDriverUtil.ONE_SECOND_WAIT, 
                $"Unable to locate standard details sidebar button - {StandardDetailsSidebarButton}"
                ).Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            WebDriverUtil.GetWebElement(EditButtonSidebar,WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate edit button - {EditButtonSidebar}").Click();
            WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate DELETE button - {DeleteButton}").Click();

            WebDriverUtil.GetWebElement(ConfirmPopupButton, WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate confirm button - {ConfirmPopupButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Standard Error - {alert.Text}");
            }
        }
        public static void ClickOnNewStandardElement()
        {
            LogWriter.WriteLog("Executing StandardPage.NewStandardElement");
            if (WebDriverUtil.GetWebElement(NewStandardElement, WebDriverUtil.ONE_SECOND_WAIT, $"unable to find the new standard element button - {NewStandardElement}") != null)
            {
                WebDriverUtil.GetWebElement(NewStandardElement, WebDriverUtil.ONE_SECOND_WAIT, $"unable to find the new standard element button - {NewStandardElement}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
        }
        public static void VerifyNewStandardElementPopup(string value)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyNewStandardElementPopup");
            var newStandardElementPopup = string.Format(NewStandardElementPopup, value);
            IWebElement standardElementPopup = WebDriverUtil.GetWebElement(newStandardElementPopup, WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            if (standardElementPopup == null)
            {
                standardElementPopup = WebDriverUtil.GetWebElement(PageTitle, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
                throw new Exception($"We supposed to get standard element title - {value} but found - {standardElementPopup.Text}");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void SelectElementType(string value)
        {
            LogWriter.WriteLog("Executing StandardPage.selectElementType");
            if (WebDriverUtil.GetWebElement(StandardElementPopup, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate standard element popup - {StandardElementPopup}") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(StandardElementDropdown, WebDriverUtil.ONE_SECOND_WAIT, 
                    WebDriverUtil.NO_MESSAGE)).SelectByText(value);
                WebDriverUtil.GetWebElement(StandardElementOkButton, WebDriverUtil.NO_WAIT, $"UNABLE TO LOCATE OK BUTTON - {StandardElementOkButton}").Click();
            }

        }
        public static void DeleteStandardIfExist(string standardName)
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteStandardIfExist");
            var specificStandardRecord = string.Format(StandardRecord, standardName);
            ClearAllFilter();
            SearchStandard(standardName);
            IWebElement record = WebDriverUtil.GetWebElementAndScroll(specificStandardRecord, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (record != null)
            {
                DeleteStandardByName(standardName);
            }

        }
        public static void DeleteStandardByName(string standardName)
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteStandardByName");
            var specificStandardRecord = string.Format(StandardRecord, standardName);
            WebDriverUtil.GetWebElement(specificStandardRecord, WebDriverUtil.NO_WAIT,
            $"Unable to locate Standard  record on StandardPage page - {specificStandardRecord}").Click();

            if (WebDriverUtil.GetWebElement(OpenEditSidebarForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) == null)
            {
                WebDriverUtil.GetWebElement(StandardDetailsSidebarButton,
                WebDriverUtil.ONE_SECOND_WAIT,
                $"Unable to locate standard details sidebar button - {StandardDetailsSidebarButton}").Click();

                WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            }
            WebDriverUtil.GetWebElement(EditButtonSidebar, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate edit button - {EditButtonSidebar}").Click();
            WebDriverUtil.GetWebElement(DeleteButton, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate DELETE button - {DeleteButton}").Click();

            WebDriverUtil.GetWebElement(ConfirmPopupButton, WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate confirm button - {ConfirmPopupButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(ConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete Standard Error - {alert.Text}");
            }
        }
        public static void SelectStandard(string standard)
        {
            LogWriter.WriteLog("Executing StandardPage.SelectStandard");
            var standardName = string.Format(StandardByName, standard);
            if(WebDriverUtil.GetWebElement(StandardPageTitle, WebDriverUtil.ONE_SECOND_WAIT,WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(standardName, WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate the Standard By name - {standardName}").Click();
                WebDriverUtil.WaitFor(WebDriverUtil.TWO_SECOND_WAIT);
            }
        }
        public static void AddStandardElementWithGivenInput(Table inputData)
        {
            LogWriter.WriteLog("Executing StandardPage.AddStandardElementWithGivenInput");
            var dictionary = Util.ConvertToDictionary(inputData);
            BaseClass._TestData.Value = Util.DictionaryToString(dictionary);

            if (Util.ReadKey(dictionary, "Name") != null)
            {
                WebDriverUtil.GetWebElement(StandardElementNameTag, WebDriverUtil.NO_WAIT,
                    $"Unable to locate name input - {StandardElementNameTag}").SendKeys(dictionary["Name"]);
            }

            if(Util.ReadKey(dictionary, "Frequency") != null)
            {
                WebDriverUtil.GetWebElement(StandardElementFrequencyTag, WebDriverUtil.NO_WAIT,
                    $"Unable to locate frequency input - {StandardElementFrequencyTag}").SendKeys(dictionary["Frequency"]);
            }

            if (Util.ReadKey(dictionary, "Unit of Measure") != null)
            {
                new SelectElement(WebDriverUtil.GetWebElement(StandardElementUomTag, WebDriverUtil.NO_WAIT,
                     $"Unable to locate UNIT OF MEASURE INPUT - {StandardElementUomTag}")).SelectByText(dictionary["Unit of Measure"]);

            }

            if (Util.ReadKey(dictionary, "Time (Seconds)") != null)
            {
                WebDriverUtil.GetWebElement(StandardElementTimeTag, WebDriverUtil.NO_WAIT,
                    $"Unable to locate time input - {StandardElementTimeTag}").Clear();
                WebDriverUtil.GetWebElement(StandardElementTimeTag, WebDriverUtil.NO_WAIT,
                    $"Unable to locate time input - {StandardElementTimeTag}").SendKeys(dictionary["Time (Seconds)"]);
            }



            WebDriverUtil.GetWebElement(SaveButton,
                WebDriverUtil.NO_WAIT,
                $"Unable to locate Save Button- {SaveButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.FIVE_SECOND_WAIT);
            if (WebDriverUtil.GetWebElement(NewStandardElementForm, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                IWebElement errorMessage = WebDriverUtil.GetWebElementAndScroll(FormInputFieldErrorXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                if (errorMessage == null)
                {
                    IWebElement errorMsg = WebDriverUtil.GetWebElementAndScroll(ElementAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                    if (errorMsg == null)
                    {
                        IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
                        if (alert == null)
                        {
                            WebDriverUtil.WaitForWebElementInvisible(NewStandardElementForm, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
                        }
                        else
                        {
                            throw new Exception($"Unable to create new Standard Error - {alert.Text}");
                        }
                    }
                }

            }

        }
        public static void VerifyCreatedStandardElement(string standardElement)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyCreatedStandardElement");
            var specificStandardElement = string.Format(CreatedStandardElement, standardElement);
            if (WebDriverUtil.GetWebElement(StandardElementContent, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(specificStandardElement,
                    WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate the Standard element - {specificStandardElement}");
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void DeleteStandardElement()
        {
            LogWriter.WriteLog("Executing StandardPage.DeleteStandardElementByName");
            if(WebDriverUtil.GetWebElement(StandardDetailsSidebar, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(StandardSidebar, WebDriverUtil.ONE_SECOND_WAIT, 
                    $"Unable to locate standard sidebar button {StandardSidebar}").Click();
            }
            WebDriverUtil.GetWebElement
                (StandardElementDropdownButton,
                WebDriverUtil.ONE_SECOND_WAIT, 
                $"Unable to locate the standard element dropdown button - {StandardElementDropdownButton}").Click();

            WebDriverUtil.GetWebElement(StandardElementDeleteButton, 
            WebDriverUtil.ONE_SECOND_WAIT, $"Unable to locate delete button - {StandardElementDeleteButton}" 
            ).Click();

            WebDriverUtil.GetWebElement(ConfirmButton, WebDriverUtil.TWO_SECOND_WAIT, $"Unable to locate confirm button - {ConfirmButton}").Click();
            WebDriverUtil.WaitFor(WebDriverUtil.ONE_SECOND_WAIT);
            WebDriverUtil.WaitForWebElementInvisible("//button[contains(text(),'Deleting...')]", WebDriverUtil.MAX_WAIT, WebDriverUtil.NO_MESSAGE);
            IWebElement alert = WebDriverUtil.GetWebElementAndScroll(ErrorAlertToastXpath, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            if (alert == null)
            {
                WebDriverUtil.WaitForWebElementInvisible(StandardElementConfirmPopup, WebDriverUtil.PERFORM_ACTION_TIMEOUT, "Timeout - " + WebDriverUtil.PERFORM_ACTION_TIMEOUT + " Sec. Application taking too long time to perform operation");
            }
            else
            {
                throw new Exception($"Unable to delete StandardElement Error - {alert.Text}" );
            }
            

        }
        public static void SearchStandard(string standardName)
        {
                LogWriter.WriteLog("Executing StandardPage.ClickOnProfilingTab");
                var standardFilterInput = string.Format(StandardFilterInput, FindColumnIndexInStandard(Name));
                WebDriverUtil.GetWebElement(standardFilterInput, WebDriverUtil.NO_WAIT,
                $"Unable to locate location filter input on Standard page - {StandardFilterInput}").SendKeys(standardName);
                WebDriverUtil.WaitForAWhile();
                WaitForLoading();
        }
        public static void WaitForLoading()
        {
            WebDriverUtil.WaitForWebElementInvisible(PageLoader, WebDriverUtil.DEFAULT_WAIT, WebDriverUtil.NO_MESSAGE);
        }
        public static void ClearAllFilter()
        {
            LogWriter.WriteLog("Executing StandardPage.ClickOnProfilingTab");
            IWebElement clearFilterButton = WebDriverUtil.GetWebElement(ClearFilterButton, WebDriverUtil.NO_WAIT, WebDriverUtil.NO_MESSAGE);
            if (clearFilterButton != null)
            {
                clearFilterButton.Click();
                WaitForLoading();
            }
        }
        public static void VerifyFrequencyIsEmpty()
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyFrequencyIsEmpty");
            if(WebDriverUtil.GetWebElement(NewStandardElementForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(StandardElementFrequencyAlert, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE);
            }
            BaseClass._AttachScreenshot.Value = true;
        }
        public static void VerifyUomInDropDown(string uom)
        {
            LogWriter.WriteLog("Executing StandardPage.VerifyUOMInDropDown");
            var standardElementUomValue = string.Format(StandardElementUomValueInDropdown, uom);
            if(WebDriverUtil.GetWebElement(NewStandardElementForm, WebDriverUtil.ONE_SECOND_WAIT, WebDriverUtil.NO_MESSAGE) != null)
            {
                WebDriverUtil.GetWebElement(StandardElementUomTag, 
                 WebDriverUtil.ONE_SECOND_WAIT, 
                 $"unable to locate units of measure in standard element - {StandardElementUomTag}"
                 ).Click();

                WebDriverUtil.GetWebElement(standardElementUomValue, 
                    WebDriverUtil.ONE_SECOND_WAIT, 
                    $"Unable to locate UOM value in standard element dropdown - {standardElementUomValue}"
                    );
            }
            BaseClass._AttachScreenshot.Value = true;

        }
        public static int FindColumnIndexInStandard(string headerName)
        {
            LogWriter.WriteLog("Executing StandardPage.FindColumnIndexInStandard");
            IList<IWebElement> headers = SeleniumDriver.Driver().FindElements(By.XPath(StandardTableHeader));
            int index = 0;
            foreach (IWebElement header in headers)
            {
                index++;
                if (headerName.ToLower().Equals(header.Text.ToLower()))
                {
                    break;
                }
            }
            index++;
            return index;
        }
    }
}
