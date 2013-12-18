package com.imasson.auto.wechatuiauto;

import java.util.HashSet;

import android.view.KeyEvent;

import com.android.uiautomator.core.UiObject;
import com.android.uiautomator.core.UiObjectNotFoundException;
import com.android.uiautomator.core.UiScrollable;
import com.android.uiautomator.core.UiSelector;
import com.android.uiautomator.testrunner.UiAutomatorTestCase;

public class UiMainTest extends UiAutomatorTestCase {
	
	private static final int MAX_FRIEND_LOOP = 300;
	private static final int FRIEND_ITEM_COUNT_ON_SCEEN = 8;
//	private static final int FRIEND_ITEM_HEIGHT = 200;
	
	private int mHandledFriendCount = 0;
	
	private HashSet<String> mHandledFriendNameSet = new HashSet<String>();
	
	public void testSendGreetToPeopleNearby() throws UiObjectNotFoundException {

		sleep(500);
		
		prepareFriendList();
		
		loopAllFriendsAndSendAtList();
		
		getUiDevice().pressBack();
		
//		sleep(500);
//		
//		getUiDevice().pressBack();
	}

	
	private void loopAllFriendsAndSendAtList() throws UiObjectNotFoundException {
		UiScrollable listView = new UiScrollable(new UiSelector().className("android.widget.ListView"));
		if (!listView.exists()) {
			// some thing wrong!
			throw new UiObjectNotFoundException("Can't find friend ListView!");
		}
		listView.setAsVerticalList();
		
		do {
//			listView.getChildByInstance(new UiSelector()
//							.className("android.widget.TextView")
//							.textContains("Within"), 
//						0)
//					.clickAndWaitForNewWindow(3000L);
//			boolean success = handleFriendItem();
//			if (success) {
//				mHandledFriendCount++;
//			}
			
			loopAllFriendsAndSendAtScreen(1);
			
			if (mHandledFriendCount >= MAX_FRIEND_LOOP) break;
		} while (listView.scrollForward());
		
		if (mHandledFriendCount < MAX_FRIEND_LOOP) {
			loopAllFriendsAndSendAtScreen(0);
		}
	}
	
	private boolean loopAllFriendsAndSendAtScreen(int trimEndCount) throws UiObjectNotFoundException {
		int sum = FRIEND_ITEM_COUNT_ON_SCEEN - trimEndCount;
		for (int i = 0; i < sum; i++) {
			new UiObject(new UiSelector()
					.className("android.widget.TextView")
					.textContains("以内")
					.instance(i)
				).clickAndWaitForNewWindow(3000L);
			
			boolean success = handleFriendItem();
			if (success) {
				mHandledFriendCount++;
			}
			
			sleep(300);
			
			if (mHandledFriendCount >= MAX_FRIEND_LOOP) {
				return false;
			}
		}
		return true;
	}

	private boolean handleFriendItem() throws UiObjectNotFoundException {
		UiObject sendButton = new UiObject(new UiSelector().className(
				"android.widget.Button").text("打招呼"));
		if (sendButton.exists()) {
			// cancel duplication
			String name = fetchFriendName();
			if (name != null && !mHandledFriendNameSet.contains(name)) {
				System.out.println("send greeting to " + name);
				mHandledFriendNameSet.add(name);
			} else {
				getUiDevice().pressBack();
				return false;
			}
						
			sendButton.clickAndWaitForNewWindow(3000L);
			sendGreeting();
			
			return true;
			
		} else {
			// not a friend item
			getUiDevice().pressBack();
		}
		
		return false;
	}

	private void sendGreeting() throws UiObjectNotFoundException {
		// set text to send
		UiObject edittext = new UiObject(new UiSelector().className("android.widget.EditText"));
//		edittext.setText("Hello");
		// TODO or paste text from clipboard
//		edittext.click();
//		sleep(100);
		getUiDevice().pressKeyCode(KeyEvent.KEYCODE_V, KeyEvent.META_CTRL_ON);
		
		sleep(200);

		// press "send" !
		new UiObject(new UiSelector().className("android.widget.TextView").text("发送"))
			.clickAndWaitForNewWindow(3000L);
		
		// wait
		UiSelector selectortTitle = new UiSelector().className("android.widget.TextView").text("详细资料");
		while (true) {
			if (new UiObject(selectortTitle).exists()) {
				break;
			}
			sleep(100);
		}
		
		getUiDevice().pressBack();
	}

	private String fetchFriendName() throws UiObjectNotFoundException {
		UiObject nameView = new UiObject(new UiSelector()
				.className("android.widget.TextView")
				.instance(2));
		if (nameView.exists()) {
			return nameView.getText();
		}
		return null;
	}


	private void prepareFriendList() throws UiObjectNotFoundException {
		// click "discover"
		new UiObject(new UiSelector()
				.className("android.widget.RadioButton")
				.text("发现")
			).click();
		sleep(500);
		
		// click "people nearby"
		new UiObject(new UiSelector()
				.text("附近的人")
			).clickAndWaitForNewWindow(3000L);
		sleep(500);
		
		UiObject searchButton = new UiObject(new UiSelector().className("android.widget.Button").text("搜索"));
		if (searchButton.exists()) {
			searchButton.clickAndWaitForNewWindow(3000L);
		}
		
		System.out.println("hellllllllllllllllo!");
		
		// confirm "Note" Dialog if need
		if (new UiObject(new UiSelector().textContains("提示")).exists()) {
			new UiObject(new UiSelector()
					.className("android.widget.Button")
					.text("确定")
				).clickAndWaitForNewWindow(3000);
		}
		
		// wait until search complete
		UiSelector selectorForSearching = new UiSelector().textContains("正在确定你的位置");
		UiSelector selectorForLoading = new UiSelector().textContains("正在查找附近的人");
		while (true) {
			if (!(new UiObject(selectorForLoading).exists()) &&
					!(new UiObject(selectorForSearching).exists())) {
				break;
			}
			sleep(100);
		}
	}
}
